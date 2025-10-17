namespace Core.Repositories
{
    public interface IPdfProcessor
    {
        Task<(byte[]? correctedPdfBytes, string correctedFilePath)> CorrectOrientationAsync(string filePath);
        Task<string> ExtractTextAsync(string filePath);
    }
}
