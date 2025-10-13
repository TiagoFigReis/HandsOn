import os
import json
import google.generativeai as genai
from typing import Dict
from Core.interfaces.ai_extractor import IAiExtractor
from Infrastructure.config import settings
from fastapi import HTTPException

class GeminiExtractor(IAiExtractor):
    def __init__(self):
        genai.configure(api_key=settings.GOOGLE_API_KEY)
        self._model = genai.GenerativeModel(model_name='gemini-2.5-flash')
    
    def extract_soil_data(self, file_path: str, file_text: str) -> Dict:
        prompt = self._get_soil_extraction_prompt()
        return self._extract_data(file_path, file_text, prompt)

    def extract_foliar_data(self, file_path: str, file_text: str) -> Dict:
        prompt = self._get_foliar_extraction_prompt()
        return self._extract_data(file_path, file_text, prompt)

    def _extract_data(self, file_path: str, file_text: str, prompt: str) -> Dict:
        if not os.path.exists(file_path):
            raise HTTPException(status_code=404, detail=f"Arquivo não encontrado: {file_path}")

        try:
            uploaded_file = genai.upload_file(path=file_path, display_name=os.path.basename(file_path))
        except Exception as e:
            raise HTTPException(status_code=500, detail=f"Falha no upload do arquivo para a API GenAI: {e}")

        try:
            response = self._model.generate_content([prompt, "### TEXTO EXTRAÍDO:\n" + file_text, uploaded_file])
            cleaned_response = response.text.strip().replace("```json", "").replace("```", "")
        except Exception as e:
            raise HTTPException(status_code=502, detail=f"Erro ao chamar a API do Gemini: {e}")

        try:
            data = json.loads(cleaned_response)
            return data
        except json.JSONDecodeError as e:
            raise HTTPException(
                status_code=500,
                detail={
                    "erro": "A resposta da API não é um JSON válido.",
                    "detalhes": str(e),
                    "resposta_recebida": cleaned_response,
                },
            )

    def _get_soil_extraction_prompt(self) -> str:
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
            - O enxofre em alguns casos pode estar representado como SO4.
            - Retorne os valores de ponto flutuante sempre com 2 casas decimais.
        4.  **Informação Ausente**: Se uma informação específica não for encontrada, use o valor `null`. Não invente dados.
        5.  **Extrator**: Tente identificar o método extrator usado, especialmente para Fósforo e micronutrientes.

        ### ESQUEMA JSON DE SAÍDA OBRIGATÓRIO:
        ```json
        {json_schema}
        ```
        Sua resposta deve conter APENAS o código JSON, sem nenhum texto introdutório, comentários ou explicações adicionais.
        """
        return prompt

    def _get_foliar_extraction_prompt(self) -> str:
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