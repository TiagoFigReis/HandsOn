from typing import Dict
from Core.interfaces.pdf_processor import IPdfProcessor
from Core.interfaces.ai_extractor import IAiExtractor

class ExtractionService:
    def __init__(self, pdf_processor: IPdfProcessor, ai_extractor: IAiExtractor):
        self._pdf_processor = pdf_processor
        self._ai_extractor = ai_extractor

    def extract_data_from_pdf(self, file_path: str, analysis_type: int) -> Dict:
        """
        Orquestra o processo de correção, extração de texto e extração de dados com IA.
        """
        corrected_path = self._pdf_processor.correct_orientation(file_path)
        
        extracted_text = self._pdf_processor.extract_text(corrected_path)

        if not extracted_text:
            raise ValueError("Não foi possível extrair texto do arquivo.")

        if analysis_type == 0: # Solo
            structured_data = self._ai_extractor.extract_soil_data(corrected_path, extracted_text)
        else: # Foliar
            structured_data = self._ai_extractor.extract_foliar_data(corrected_path, extracted_text)

        return structured_data