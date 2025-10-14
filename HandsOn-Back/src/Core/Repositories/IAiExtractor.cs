using Core.Entities;
using Core.Enums;

namespace Core.Repositories
{
    public interface IAiExtractor
    {
        Task<DadosAnalise> ExtractFileDataAsync(byte[] fileData, string fileText, Tipo analysisType);
    }
}

