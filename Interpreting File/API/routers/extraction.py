import os
import shutil
from fastapi import APIRouter, UploadFile, File, HTTPException, Body
from typing import Annotated

from Infrastructure.pdf.pdfplumber_processor import PdfplumberProcessor
from Infrastructure.ai.gemini_extractor import GeminiExtractor
from Application.services.extraction_service import ExtractionService

router = APIRouter()

pdf_processor = PdfplumberProcessor()
ai_extractor = GeminiExtractor()
extraction_service = ExtractionService(pdf_processor, ai_extractor)

@router.post("/extrair-dados-pdf/", response_model=dict)
async def process_file_and_extract_data(
    file: UploadFile = File(..., description="Arquivo de laudo (PDF)."),
    type: Annotated[int, Body(embed=True, description="Tipo de análise: 0 para Solo, 1 para Foliar")] = 0
):
    """
    Recebe um arquivo PDF, extrai o texto e o estrutura usando IA.
    """
    temp_dir = "temp_files"
    os.makedirs(temp_dir, exist_ok=True)
    temp_file_path = os.path.join(temp_dir, file.filename)
    corrected_pdf_path = None

    try:
        with open(temp_file_path, "wb") as buffer:
            shutil.copyfileobj(file.file, buffer)

        structured_data = extraction_service.extract_data_from_pdf(temp_file_path, type)
        return structured_data

    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    except Exception as e:
       
        if isinstance(e, HTTPException):
            raise e
        raise HTTPException(status_code=500, detail=f"Ocorreu um erro inesperado: {e}")
    finally:
       
        if os.path.exists(temp_file_path):
            base_name, _ = os.path.splitext(temp_file_path)
            corrected_pdf_path = f"{base_name}_corrigido.pdf"
            if os.path.exists(corrected_pdf_path):
                os.remove(corrected_pdf_path)
            os.remove(temp_file_path)