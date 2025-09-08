import os
import json
import shutil
from fastapi import FastAPI, UploadFile, File, HTTPException
from pathlib import Path
from fastapi.middleware.cors import CORSMiddleware
from collections import Counter
import pikepdf

import pdfplumber
import google.generativeai as genai

from dotenv import load_dotenv

load_dotenv()


GOOGLE_API_KEY = os.getenv("GOOGLE_API_KEY")

if not GOOGLE_API_KEY:
    raise ValueError("A variável de ambiente GOOGLE_API_KEY não foi definida.")

genai.configure(api_key=GOOGLE_API_KEY)

# Cria a instância da aplicação FastAPI
app = FastAPI(
    title="API de Extração de Dados de Análise de Solo",
    description="Faça o upload de um laudo de solo em PDF para extrair os dados em formato JSON estruturado.",
    version="1.0.0"
)

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

def detectar_rotacao_conteudo(page: pdfplumber.page.Page) -> int:
    """
    Detecta a rotação dominante do conteúdo de uma página (0, 90, 180, 270)
    analisando a matriz de transformação de cada caractere.

    Args:
        page: Um objeto de página do pdfplumber.

    Returns:
        A rotação detectada em graus (0, 90, 180 ou 270).
    """
    if not page.chars:
        return 0 

    votes = Counter()
    for char in page.chars:
        # A matriz de transformação (a, b, c, d, e, f) diz a orientação
        a, b, c, d, _, _ = char["matrix"]
        
        # detectar a rotação baseada nos sinais da matriz
        if a > 0 and d > 0 and abs(b) < 0.1 and abs(c) < 0.1:
            votes[0] += 1  # Normal
        elif b > 0 and c < 0 and abs(a) < 0.1 and abs(d) < 0.1:
            votes[270] += 1 # Rotacionado +90 graus (texto desce)
        elif a < 0 and d < 0 and abs(b) < 0.1 and abs(c) < 0.1:
            votes[180] += 1 # De cabeça para baixo
        elif b < 0 and c > 0 and abs(a) < 0.1 and abs(d) < 0.1:
            votes[90] += 1 # Rotacionado +270 graus (texto sobe)

    if not votes:
        return 0

    # Retorna a rotação que teve mais "votos"
    return votes.most_common(1)[0][0]

def corrigir_orientacao_completa(caminho_arquivo_original: str) -> str:
    """
    Analisa e corrige a orientação do conteúdo de cada página de um PDF para todas
    as rotações possíveis (0, 90, 180, 270).

    Args:
        caminho_arquivo_original: O caminho para o PDF original.

    Returns:
        O caminho para o arquivo corrigido ou o original se nenhuma correção foi feita.
    """
    correcoes_necessarias = {} # Dicionário para guardar {num_pagina: rotacao_a_aplicar}
    
    with pdfplumber.open(caminho_arquivo_original) as pdf:
        for i, page in enumerate(pdf.pages):
            rotacao_conteudo = detectar_rotacao_conteudo(page)
            
            if rotacao_conteudo != 0:
                # A rotação a ser aplicada na PÁGINA é o que falta para 360°
                rotacao_para_corrigir = (360 - rotacao_conteudo) % 360
                correcoes_necessarias[i] = rotacao_para_corrigir
               

    if not correcoes_necessarias:
        return caminho_arquivo_original

    base_name = os.path.basename(caminho_arquivo_original)
    nome_arquivo_corrigido = os.path.join(os.path.dirname(caminho_arquivo_original), f"{os.path.splitext(base_name)[0]}_corrigido_final.pdf")

    with pikepdf.open(caminho_arquivo_original) as pdf_para_corrigir:
        for num_pagina, rotacao_a_aplicar in correcoes_necessarias.items():
            pagina = pdf_para_corrigir.pages[num_pagina]
            
            pagina.Rotate = (rotacao_a_aplicar) % 360
        
        pdf_para_corrigir.save(nome_arquivo_corrigido)

    return nome_arquivo_corrigido


def extract_text_from_pdf(pdf_path: str) -> str:
    """
    Extrai texto e tabelas de um arquivo PDF, formatando as tabelas em Markdown
    para facilitar a interpretação pela IA.

    Args:
        pdf_path: O caminho para o arquivo PDF.

    Returns:
        Uma string contendo o texto e as tabelas formatadas do PDF.
        Retorna uma string vazia se o arquivo não for encontrado.
    """
    if not os.path.exists(pdf_path):
        print(f"Erro: Arquivo não encontrado em '{pdf_path}'")
        return ""

    full_content = ""
    with pdfplumber.open(pdf_path) as pdf:
        for i, page in enumerate(pdf.pages):
            full_content += f"--- CONTEÚDO DA PÁGINA {i+1} ---\n\n"

            # Extrai o texto normal da página
            # Ajuste da tolerância para agrupar melhor o texto
            text = page.extract_text(x_tolerance=2)
            if text:
                full_content += "### Texto da Página:\n"
                full_content += text + "\n\n"

            # Extrai as tabelas da página
            tables = page.extract_tables()
            if tables:
                full_content += "### Tabelas Encontradas:\n"
                for j, table in enumerate(tables):
                    # Filtra linhas vazias ou com valores None
                    clean_table = [row for row in table if any(
                        cell is not None and cell.strip() != '' for cell in row)]

                    if not clean_table:
                        continue

                    full_content += f"--- Tabela {j+1} ---\n"
                    # Converte a lista de listas para uma tabela em formato Markdown
                    # Cabeçalho
                    header = " | ".join(str(cell or "").replace(
                        "\n", " ") for cell in clean_table[0])
                    separator = " | ".join(["---"] * len(clean_table[0]))
                    # Corpo da tabela
                    body = "\n".join([" | ".join(str(cell or "").replace(
                        "\n", " ") for cell in row) for row in clean_table[1:]])

                    markdown_table = f"| {header} |\n| {separator} |\n{body}\n\n"
                    full_content += markdown_table

    return full_content


def get_extraction_prompt() -> str:
    """
    Monta o prompt detalhado para enviar ao modelo de IA.
    """
    json_schema = """
    {
        "amostras_solo": [
                {
                "id_amostra": "string ou null",
                "identificacao_talhao": "string ou null",
                "cultura": "string ou null",
                "fosforo_p": "number ou null",
                "potassio_k": "number ou null",
                "calcio_ca": "number ou null",
                "magnesio_mg": "number ou null",
                "Aluminio_al":  "number ou null",
                "ph_h2o": "number ou null",
                "acidez_potencial_h_al_cmolc_dm3": "number ou null",
                "soma_bases_sb_cmolc_dm3": "number ou null",
                "ctc_ph7_T_cmolc_dm3": "number ou null",
                "saturacao_bases_v_percent": "number ou null",
                "materia_organica_mo_percent": "number ou null",
                "boro_b": "number ou null",
                "cobre_cu": "number ou null",
                "ferro_fe": "number ou null",
                "manganes_mn": "number ou null",
                "zinco_zn": "number ou null",
                "enxofre_s": "number ou null"
                }
            }
        ]
    }
    """
    prompt = f"""
    Você é um assistente especialista em agronomia e análise de dados de solo. Sua tarefa é extrair e estruturar as informações de laudos de análise de solo.

    Analise o PDF ou a Imagem e o texto extraído do laudo de solo fornecido. O laudo pode ter uma ou múltiplas amostras e o layout pode ser complexo.

    Extraia todas as informações relevantes e retorne-as estritamente no formato JSON definido pelo esquema abaixo.

    ### REGRAS IMPORTANTES:
    1.  **Múltiplas Amostras**: Popule a lista "amostras" no JSON com um objeto para cada amostra encontrada no laudo.
    2.  **Valores Numéricos**: Converta todos os valores numéricos para o tipo `number`, usando ponto como separador decimal.
    3.  **Unidades**:
        - Normalize Matéria Orgânica (M.O.) para porcentagem (%). Se estiver em g/kg, divida por 10. Se estiver em dag/kg, o valor numérico já é a porcentagem.
        - Normalize Ca, Mg, K, H+Al para cmolc/dm³. Se estiver em mmolc/dm³, divida por 10. Se o K estiver em mg/dm³ converta para cmolc/dm³ dividindo por 391.
        - Se não houver distinção entre pH H2O e pH CaCl2, assuma como pH CaCl2.
        - O pH H2O é valor do pH CaCl2 + 0.6.
    4.  **Informação Ausente**: Se uma informação específica não for encontrada, use o valor `null`. Não invente dados.
    5.  **Extrator**: Tente identificar o método extrator usado, especialmente para Fósforo e micronutrientes.

    ### ESQUEMA JSON DE SAÍDA OBRIGATÓRIO:
    ```json
    {json_schema}
    ```
    Sua resposta deve conter APENAS o código JSON, sem nenhum texto introdutório, comentários ou explicações adicionais.
    """
    return prompt


def extract_soil_data_with_ai(file_path: str, file_text: str) -> dict:
    """
    Extrai dados de um laudo de solo em PDF usando uma abordagem híbrida
    com o Google Gemini

    Args:
        pdf_path: Caminho para o arquivo PDF.
        pdf_text: Texto extraido do PDF.

    Returns:
        Um dicionário Python com os dados extraídos.

    Raises:
        HTTPException: Em caso de erro de arquivo, na extração, 
                       comunicação com a API ou parse da resposta.
    """
    # 0. Verificação da existência do arquivo
    if not os.path.exists(file_path):
        raise HTTPException(status_code=404, detail={
                            "erro": f"Arquivo não encontrado: {file_path}"})

    # 1. Upload do Arquivo para a API
    try:
        arquivo_pdf = genai.upload_file(
            path=file_path, display_name=os.path.basename(file_path))
    except Exception as e:
        # Captura erros de upload (ex: falha de autenticação, problema de rede)
        raise HTTPException(status_code=500, detail={
                            "erro": f"Falha no upload do arquivo para a API GenAI: {str(e)}"})

    # 2. Preparação do Modelo e do Prompt
    prompt = get_extraction_prompt()
    model = genai.GenerativeModel(
        model_name='gemini-2.5-flash',
    )

    # 3. Geração de Conteúdo
    cleaned_response = ""
    try:
        response = model.generate_content(
            [prompt, "### TEXTO EXTRAÍDO DO PDF PARA REFERÊNCIA:\n" +
                file_text, arquivo_pdf]
        )
        # Limpa a resposta para garantir que temos apenas o JSON
        cleaned_response = response.text.strip().replace(
            "```json", "").replace("```", "")

    except Exception as e:
        # Captura erros durante a chamada da API (ex: cota excedida, erro interno do servidor)
        raise HTTPException(status_code=502, detail={
            "erro": f"Ocorreu um erro ao chamar a API do Gemini: {str(e)}"
        })

    # 4. Validação e Parse do JSON
    try:
        # Converte a string de resposta em um JSON
        data = json.loads(cleaned_response)
        return data
    except json.JSONDecodeError as e:
        # Captura o erro se a IA não retornar um JSON válido
        raise HTTPException(status_code=500, detail={
            "erro": "A resposta da API não estava em um formato JSON válido.",
            "detalhes_do_erro": str(e),
            "resposta_recebida": cleaned_response  # Inclui a resposta para depuração
        })


def get_foliar_extraction_prompt() -> str:
    """
    Monta o prompt detalhado para enviar ao modelo de IA para análise foliar.

    Returns:
        O prompt completo com as instruções e o texto a ser analisado.
    """

    json_schema = """
    {
        "amostras_foliar": [
                {
                "id_amostra": "string ou null",
                "identificacao_talhao": "string ou null",
                "cultura": "string ou null",
                "nitrogenio_n": "number ou null",
                "fosforo_p": "number ou null",
                "potassio_k": "number ou null",
                "calcio_ca": "number ou null",
                "magnesio_mg": "number ou null",
                "enxofre_s": "number ou null",
                "boro_b": "number ou null",
                "cobre_cu": "number ou null",
                "ferro_fe": "number ou null",
                "manganes_mn": "number ou null",
                "zinco_zn": "number ou null"
                }
            }
        ]
    }
    """

    prompt = f"""
    Você é um assistente especialista em agronomia e análise de dados de laudos foliares. Sua tarefa é extrair e estruturar as informações de laudos de análise de folha.

    Analise o PDF e o texto do laudo foliar fornecido abaixo. O laudo pode ter uma ou múltiplas amostras e o layout é desconhecido.

    Extraia todas as informações relevantes e retorne-as estritamente no formato JSON definido pelo esquema abaixo sem erros.

    ### REGRAS IMPORTANTES:
    1.  **Múltiplas Amostras**: Popule a lista "amostras" no JSON com um objeto para cada amostra encontrada no laudo.
    2.  **Valores Numéricos**: Converta todos os valores numéricos para o tipo `number`, usando ponto como separador decimal.
    3.  **Conversão de Unidades Obrigatória**:
        - **Macronutrientes (N, P, K, Ca, Mg, S)**: Normalize todos os valores para grama por quilo (g/kg). Se a unidade original for porcentagem (%), multiplique o valor por 10. Se já estiver em g/kg, mantenha o valor.
        - **Micronutrientes (B, Cu, Fe, Mn, Zn)**: Normalize todos os valores para ppm. Se a unidade for mg/kg, mantenha o valor numérico, pois mg/kg é equivalente a ppm.
    4.  **Informação Ausente**: Se uma informação específica não for encontrada, use o valor `null`. Não invente dados.
    5.  **Identificação**: Preencha os campos de metadados como nome do produtor, propriedade, município e laboratório com base nas informações do laudo. A data de emissão (`data_emissao`) refere-se à data de impressão ou saída do laudo.

    ### ESQUEMA JSON DE SAÍDA OBRIGATÓRIO:
    {json_schema}

    Sua resposta deve conter APENAS o código JSON, sem nenhum texto introdutório, comentários ou explicações adicionais.

    """
    return prompt


def extract_foliar_data_with_ai(file_path: str, file_text: str) -> dict:
    """
    Extrai dados de um laudo de foliar em PDF usando uma abordagem híbrida
    com o Google Gemini

    Args:
        pdf_path: Caminho para o arquivo PDF.
        pdf_text: Texto extraido do PDF

    Returns:
        Um dicionário Python com os dados extraídos.

    Raises:
        HTTPException: Em caso de erro de arquivo, na extração, 
                       comunicação com a API ou parse da resposta.
    """
    # 0. Verificação da existência do arquivo
    if not os.path.exists(file_path):
        raise HTTPException(status_code=404, detail={
                            "erro": f"Arquivo não encontrado: {file_path}"})

    # 1. Upload do Arquivo para a API
    try:
        arquivo_pdf = genai.upload_file(
            path=file_path, display_name=os.path.basename(file_path))
    except Exception as e:
        # Captura erros de upload (ex: falha de autenticação, problema de rede)
        raise HTTPException(status_code=500, detail={
                            "erro": f"Falha no upload do arquivo para a API GenAI: {str(e)}"})

    # 2. Preparação do Modelo e do Prompt
    prompt = get_foliar_extraction_prompt()
    model = genai.GenerativeModel(
        model_name='gemini-2.5-flash',
    )

    # 3. Geração de Conteúdo
    cleaned_response = ""
    try:
        response = model.generate_content(
            [prompt, "### TEXTO EXTRAÍDO DO PDF PARA REFERÊNCIA:\n" +
                file_text, arquivo_pdf]
        )
        # Limpa a resposta para garantir que temos apenas o JSON
        cleaned_response = response.text.strip().replace(
            "```json", "").replace("```", "")

    except Exception as e:
        # Captura erros durante a chamada da API (ex: cota excedida, erro interno do servidor)
        raise HTTPException(status_code=502, detail={
            "erro": f"Ocorreu um erro ao chamar a API do Gemini: {str(e)}"
        })

    # 4. Validação e Parse do JSON
    try:
        # Converte a string de resposta em um JSON
        data = json.loads(cleaned_response)
        return data
    except json.JSONDecodeError as e:
        # Captura o erro se a IA não retornar um JSON válido
        raise HTTPException(status_code=500, detail={
            "erro": "A resposta da API não estava em um formato JSON válido.",
            "detalhes_do_erro": str(e),
            "resposta_recebida": cleaned_response  # Inclui a resposta para depuração
        })


@app.post("/extrair-dados-pdf/", response_model=dict)
async def process_file_and_extract_data(
    file: UploadFile = File(..., description="Arquivo de laudo (PDF ou Imagem)."),
    type: int = 0
):
    """
    Recebe um arquivo (PDF ou imagem), extrai o texto e o estrutura usando IA.
    """
    temp_file_path = f"temp_{file.filename}"
    corrected_pdf_path = None # Inicia como None para segurança no bloco finally

    try:
        # 1. Salva o arquivo enviado em um local temporário
        with open(temp_file_path, "wb") as buffer:
            shutil.copyfileobj(file.file, buffer)

        # 2. Determina o tipo de arquivo e extrai o texto
        is_pdf = file.content_type == "application/pdf"

        if is_pdf:
            corrected_pdf_path = corrigir_orientacao_completa(temp_file_path)
            extracted_text = extract_text_from_pdf(corrected_pdf_path)
            path_for_ai = corrected_pdf_path
        else:
            # Assume que qualquer outro formato aceito é uma imagem
            extracted_text = "Não há texto extraído"
            path_for_ai = temp_file_path

        if not extracted_text:
            raise HTTPException(
                status_code=400,
                detail="Não foi possível extrair texto do arquivo. Verifique se não é uma imagem em branco ou um PDF sem texto.",
            )

        # 3. Seleciona a função de IA apropriada com base no analysis_type
        if type == 0:
            ai_function = extract_soil_data_with_ai
        else: # analysis_type == "foliar"
            ai_function = extract_foliar_data_with_ai

        # 4. Executa a extração com IA e retorna o resultado
        structured_data = ai_function(path_for_ai, extracted_text)
        return structured_data

    finally:
        # 5. Limpa os arquivos temporários criados de forma segura
        if corrected_pdf_path and os.path.exists(corrected_pdf_path):
            os.remove(corrected_pdf_path)

        if os.path.exists(temp_file_path):
            os.remove(temp_file_path)

# --- INSTRUÇÕES PARA EXECUTAR A API ---
#    uvicorn main:app --reload
