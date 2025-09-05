import os
from collections import Counter
import pdfplumber
import pikepdf
from Core.interfaces.pdf_processor import IPdfProcessor

class PdfplumberProcessor(IPdfProcessor):
    def correct_orientation(self, file_path: str) -> str:
        correcoes_necessarias = {}
        with pdfplumber.open(file_path) as pdf:
            for i, page in enumerate(pdf.pages):
                rotacao_conteudo = self._detectar_rotacao_conteudo(page)
                if rotacao_conteudo != 0:
                    rotacao_para_corrigir = (360 - rotacao_conteudo) % 360
                    correcoes_necessarias[i] = rotacao_para_corrigir
        
        if not correcoes_necessarias:
            return file_path

        base_name = os.path.basename(file_path)
        nome_arquivo_corrigido = os.path.join(os.path.dirname(file_path), f"{os.path.splitext(base_name)[0]}_corrigido.pdf")
        
        with pikepdf.open(file_path) as pdf_para_corrigir:
            for num_pagina, rotacao_a_aplicar in correcoes_necessarias.items():
                pagina = pdf_para_corrigir.pages[num_pagina]
                pagina.Rotate = (rotacao_a_aplicar) % 360
            pdf_para_corrigir.save(nome_arquivo_corrigido)
        
        return nome_arquivo_corrigido

    def extract_text(self, file_path: str) -> str:
        if not os.path.exists(file_path):
            return ""

        full_content = ""
        with pdfplumber.open(file_path) as pdf:
            for i, page in enumerate(pdf.pages):
                full_content += f"--- CONTEÚDO DA PÁGINA {i+1} ---\n\n"
                text = page.extract_text(x_tolerance=2)
                if text:
                    full_content += "### Texto da Página:\n"
                    full_content += text + "\n\n"
                
                tables = page.extract_tables()
                if tables:
                    full_content += "### Tabelas Encontradas:\n"
                    for j, table in enumerate(tables):
                        clean_table = [row for row in table if any(cell is not None and cell.strip() != '' for cell in row)]
                        if not clean_table: continue
                        full_content += f"--- Tabela {j+1} ---\n"
                        header = " | ".join(str(cell or "").replace("\n", " ") for cell in clean_table[0])
                        separator = " | ".join(["---"] * len(clean_table[0]))
                        body = "\n".join([" | ".join(str(cell or "").replace("\n", " ") for cell in row) for row in clean_table[1:]])
                        markdown_table = f"| {header} |\n| {separator} |\n{body}\n\n"
                        full_content += markdown_table

        return full_content

    def _detectar_rotacao_conteudo(self, page: pdfplumber.page.Page) -> int:
        if not page.chars: return 0
        votes = Counter()
        for char in page.chars:
            a, b, c, d, _, _ = char["matrix"]
            if a > 0 and d > 0 and abs(b) < 0.1 and abs(c) < 0.1: votes[0] += 1
            elif b > 0 and c < 0 and abs(a) < 0.1 and abs(d) < 0.1: votes[270] += 1
            elif a < 0 and d < 0 and abs(b) < 0.1 and abs(c) < 0.1: votes[180] += 1
            elif b < 0 and c > 0 and abs(a) < 0.1 and abs(d) < 0.1: votes[90] += 1
        if not votes: return 0
        return votes.most_common(1)[0][0]