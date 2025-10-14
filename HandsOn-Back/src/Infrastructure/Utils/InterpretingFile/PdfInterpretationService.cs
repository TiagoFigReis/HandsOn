using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Utils.InterpretingFile
{
    public class PdfInterpretationService
    {
        private readonly IPdfProcessor _pdfProcessor;
        private readonly IAiExtractor _aiExtractor;
        private readonly string _tempDirectory;

        public PdfInterpretationService(IPdfProcessor pdfProcessor, IAiExtractor aiExtractor)
        {
            _pdfProcessor = pdfProcessor;
            _aiExtractor = aiExtractor;
            
            string solutionRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
            _tempDirectory = Path.Combine(solutionRoot, "Infrastructure", "Utils", "InterpretingFile", "temp_files");
        }

        public async Task<PlotsData> InterpretAndTransformPdfAsync(IFormFile file, Tipo analysisType)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Arquivo não pode ser nulo ou vazio.", nameof(file));
            }

            Directory.CreateDirectory(_tempDirectory);

            var tempFilePath = Path.Combine(_tempDirectory, $"{Guid.NewGuid()}.pdf");
            string? correctedFilePath = null;
            
            try
            {
                // 1. Salva o arquivo original temporariamente
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // 2. Corrige a orientação do PDF
                var (correctedPdfBytes, correctedPath) = await _pdfProcessor.CorrectOrientationAsync(tempFilePath);
                correctedFilePath = correctedPath; 

                var pathToProcess = correctedFilePath ?? tempFilePath;

                // 3. Extrai o texto do PDF corrigido
                string extractedText = await _pdfProcessor.ExtractTextAsync(pathToProcess);

                if (string.IsNullOrWhiteSpace(extractedText))
                {
                    throw new InvalidDataException("Não foi possível extrair texto do arquivo PDF.");
                }

                // Usa os bytes do arquivo corrigido se existirem, senão lê os bytes do original.
                byte[] fileDataForApi = correctedPdfBytes ?? await File.ReadAllBytesAsync(tempFilePath);

                // 4. Extrai os dados usando a API do gemini
                DadosAnalise structuredData;
                structuredData = await _aiExtractor.ExtractFileDataAsync(fileDataForApi, extractedText, analysisType);
                return analysisType == Tipo.Solo ? DataTransformer.TransformSoil(structuredData) : DataTransformer.TransformFoliar(structuredData);
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
                // Se um arquivo corrigido foi criado e tem um nome diferente, apaga também.
                if (correctedFilePath != null && correctedFilePath != tempFilePath && File.Exists(correctedFilePath))
                {
                    File.Delete(correctedFilePath);
                }
            }
        }
    }
}
