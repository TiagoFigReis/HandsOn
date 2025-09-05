using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Infrastructure.Utils
{
    public class FileService
    {
        public static async Task<Task> SaveFileAsync(IFormFile file, Guid analiseId, Guid userId, HttpContext context)
        {
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;

            var infrastructureFolder = Path.Combine(projectRoot, "Infrastructure", "Files", userId.ToString());

            if (!Directory.Exists(infrastructureFolder))
            {
                Directory.CreateDirectory(infrastructureFolder);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{analiseId}{fileExtension}";
            var filePath = Path.Combine(infrastructureFolder, uniqueFileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return Task.CompletedTask;
        }

        public static IActionResult GetFile(Guid id, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return new NotFoundResult();
            }

            var matchingFile = Directory.GetFiles(directoryPath, $"{id}.*").FirstOrDefault();

            if (matchingFile == null)
            {
                return new NotFoundResult();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(matchingFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var stream = new FileStream(matchingFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);

            return new FileStreamResult(stream, contentType)
            {
                FileDownloadName = Path.GetFileName(matchingFile)
            };
        }

        public static Task DeleteFileAsync(Guid analiseId, Guid userId)
        {
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            var infrastructureFolder = Path.Combine(projectRoot, "Infrastructure", "Files", userId.ToString());

            var file = Directory.GetFiles(infrastructureFolder, $"{analiseId}.*");

            if (file.Length == 0)
            {
                return Task.CompletedTask;
            }

            foreach (var filePath in file)
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }
        
        public static string CalcularHash(Stream stream)
        {
            using var sha256 = SHA256.Create();

            if (stream.CanSeek)
                stream.Position = 0;

            var hashBytes = sha256.ComputeHash(stream);

            if (stream.CanSeek)
                stream.Position = 0;

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
        public static bool ArquivosSaoIguais(Stream file1Stream, IFormFile file2)
        {
            var hash1 = CalcularHash(file1Stream);
            using var file2Stream = file2.OpenReadStream();
            var hash2 = CalcularHash(file2Stream);

            return hash1 == hash2;
        }
    }
}