from abc import ABC, abstractmethod
from typing import Dict

class IAiExtractor(ABC):
    @abstractmethod
    def extract_soil_data(self, file_path: str, file_text: str) -> Dict:
        """Extrai dados de análise de solo usando IA."""
        pass

    @abstractmethod
    def extract_foliar_data(self, file_path: str, file_text: str) -> Dict:
        """Extrai dados de análise foliar usando IA."""
        pass