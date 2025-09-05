from abc import ABC, abstractmethod

class IPdfProcessor(ABC):
    @abstractmethod
    def correct_orientation(self, file_path: str) -> str:
        """Corrige a orientação do PDF e retorna o caminho para o arquivo corrigido."""
        pass

    @abstractmethod
    def extract_text(self, file_path: str) -> str:
        """Extrai texto e tabelas de um PDF."""
        pass