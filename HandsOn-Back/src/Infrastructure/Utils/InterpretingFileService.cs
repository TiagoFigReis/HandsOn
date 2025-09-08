using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities;


namespace Infrastructure.Utils
{
    public class InterpretingFileService
    {
        private static async Task<DadosAnalise?> GetOriginalDadosAnalise(IFormFile pdf, int type)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:8000/extrair-dados-pdf/?type={type}");
            var content = new MultipartFormDataContent();

            using var stream = pdf.OpenReadStream();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(pdf.ContentType);
            content.Add(fileContent, "file", pdf.FileName);
            request.Content = content;

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return null;

            var contentResponse = await response.Content.ReadAsStringAsync();
            
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dados = JsonSerializer.Deserialize<DadosAnalise>(contentResponse, options);

            return dados;
        }
        
        public static async Task<PlotsData?> GetTransformedDadosAnalise(IFormFile pdf, int type)
        {
            var dadosOriginais = await GetOriginalDadosAnalise(pdf, type);
            
            if (dadosOriginais == null)
            {
                return null;
            }

            PlotsData? dadosTransformados;
            
            if (type == 0)
            {
                dadosTransformados = DataTransformer.TransformSoil(dadosOriginais);
            }
            else
            {
                dadosTransformados = DataTransformer.TransformFoliar(dadosOriginais);
            }
            
            
            return dadosTransformados;
        }
    }
}