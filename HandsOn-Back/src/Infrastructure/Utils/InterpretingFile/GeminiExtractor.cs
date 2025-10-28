using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Utils.InterpretingFile
{
    public class GeminiExtractor : IAiExtractor
    {
        private readonly HttpClient _httpClient;
        private readonly GeminiSettings _settings;

        // O construtor recebe um HttpClient e as configurações
        public GeminiExtractor(HttpClient httpClient, IOptions<GeminiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;

            if (string.IsNullOrEmpty(_settings.ApiKey))
            {
                throw new ArgumentException("A ApiKey do Gemini deve ser configurada.");
            }
        }

        public async Task<DadosAnalise> ExtractFileDataAsync(byte[] fileData, string fileText, Tipo analysisType)
        {
            string prompt = analysisType == Tipo.Solo ? GetSoilExtractionPrompt() : GetFoliarExtractionPrompt() ;
            var resultJson = await ExtractDataAsync(prompt, fileText, fileData);
            return JsonSerializer.Deserialize<DadosAnalise>(resultJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) 
                   ?? new DadosAnalise();
        }

        private async Task<string> ExtractDataAsync(string prompt, string fileText, byte[] fileBytes)
        {
            var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key={_settings.ApiKey}";

            // Constrói o corpo da requisição no formato JSON esperado pela API
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = prompt },
                            new { text = fileText },
                            new
                            {
                                inline_data = new
                                {
                                    mime_type = "application/pdf",
                                    data = Convert.ToBase64String(fileBytes)
                                }
                            }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0,
                    maxOutputTokens = 8192,
                    topP = 1,
                    topK = 1
                }
            };

            // Envia a requisição
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, requestBody);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro na chamada à API do Gemini: {response.StatusCode}. Detalhes: {errorContent}");
            }


            var geminiResponse = await response.Content.ReadFromJsonAsync<GeminiApiResponse>();
            
            /*Extrair resposta do modelo.
            {
                "Candidates": [  // lista de possíveis respostas
                    { 
                    "Content": {
                        "Parts": [ // lista de partes da resposta
                            { 
                                "Text": "Dados extraidos em formato json."
                            }
                        ]
                    }
                }
                ]
            } */
            
            var rawContent = geminiResponse?.Candidates[0]?.Content?.Parts[0]?.Text ?? "";
            
            // Retira o markdown de json. ```json {dados do json}``` -> {dados do json}
            var cleanedJson = Regex.Replace(rawContent, @"^```json\s*|\s*```$", "", RegexOptions.Multiline | RegexOptions.IgnoreCase).Trim();

            return cleanedJson;
        }

        private string GetSoilExtractionPrompt()
        {
            return @"
            Você é um assistente especialista em agronomia e análise de dados de solo. Sua tarefa é extrair e estruturar as informações de laudos de análise de solo.
            Analise o PDF ou a Imagem e o texto extraído do laudo de solo fornecido. O laudo pode ter uma ou múltiplas amostras e o layout pode ser complexo.
            Extraia todas as informações relevantes e retorne-as estritamente no formato JSON definido pelo esquema abaixo.
            ### REGRAS IMPORTANTES:
            1.  **Múltiplas Amostras**: Popule a lista ""amostras_solo"" no JSON com um objeto para cada amostra encontrada no laudo.
            2.  **Valores Numéricos**: Converta todos os valores numéricos para o tipo `number`, usando ponto como separador decimal.
            3.  **Unidades**:
                - Normalize Matéria Orgânica (M.O.) para porcentagem (%). Se estiver em g/kg, divida por 10. Se estiver em dag/kg, o valor numérico já é a porcentagem.
                - Normalize Ca, Mg, K, H+Al para cmolc/dm³. Se estiver em mmolc/dm³, divida por 10. Se o K estiver em mg/dm³ converta para cmolc/dm³ dividindo por 391.
                - Se não houver distinção entre pH H2O e pH CaCl2, assuma como pH CaCl2.
                - O pH H2O é valor do pH CaCl2 + 0.6.
                - O enxofre em alguns casos pode estar representado como SO4.
                - Retorne os valores de ponto flutuante sempre com 2 casas decimais.
            4.  **Informação Ausente**: Se uma informação específica não for encontrada, use o valor 0.0. Não invente dados.
            ### ESQUEMA JSON DE SAÍDA OBRIGATÓRIO:
            {
                ""amostras_solo"": [
                    {
                        ""id_amostra"": ""string ou null"",
                        ""identificacao_talhao"": ""string ou null"",
                        ""fosforo_p"": 0.0,
                        ""potassio_k"": 0.0,
                        ""calcio_ca"": 0.0,
                        ""magnesio_mg"": 0.0,
                        ""Aluminio_al"": 0.0,
                        ""ph_h2o"": 0.0,
                        ""acidez_potencial_h_al_cmolc_dm3"": 0.0,
                        ""soma_bases_sb_cmolc_dm3"": 0.0,
                        ""ctc_ph7_T_cmolc_dm3"": 0.0,
                        ""saturacao_bases_v_percent"": 0.0,
                        ""materia_organica_mo_percent"": 0.0,
                        ""boro_b"": 0.0,
                        ""cobre_cu"": 0.0,
                        ""ferro_fe"": 0.0,
                        ""manganes_mn"": 0.0,
                        ""zinco_zn"": 0.0,
                        ""enxofre_s"": 0.0
                    }
                ]
            }
            Sua resposta deve conter APENAS o código JSON, sem nenhum texto introdutório, comentários ou explicações adicionais.";
        }

        private string GetFoliarExtractionPrompt()
        {
            return @"
            Você é um assistente especialista em agronomia e análise de dados de laudos foliares. Sua tarefa é extrair e estruturar as informações de laudos de análise de folha.
            Analise o PDF e o texto do laudo foliar fornecido abaixo. O laudo pode ter uma ou múltiplas amostras e o layout é desconhecido.
            Extraia todas as informações relevantes e retorne-as estritamente no formato JSON definido pelo esquema abaixo sem erros.
            ### REGRAS IMPORTANTES:
            1.  **Múltiplas Amostras**: Popule a lista ""amostras_foliar"" no JSON com um objeto para cada amostra encontrada no laudo.
            2.  **Valores Numéricos**: Converta todos os valores numéricos para o tipo `number`, usando ponto como separador decimal.
            3.  **Conversão de Unidades Obrigatória**:
                - **Macronutrientes (N, P, K, Ca, Mg, S)**: Normalize todos os valores para grama por quilo (g/kg). Se a unidade original for porcentagem (%), multiplique o valor por 10. Se já estiver em g/kg, mantenha o valor.
                - **Micronutrientes (B, Cu, Fe, Mn, Zn)**: Normalize todos os valores para ppm. Se a unidade for mg/kg, mantenha o valor numérico, pois mg/kg é equivalente a ppm.
            4.  **Informação Ausente**: Se uma informação específica não for encontrada, use o valor 0.0. Não invente dados.
            ### ESQUEMA JSON DE SAÍDA OBRIGATÓRIO:
            {
                ""amostras_foliar"": [
                    {
                        ""id_amostra"": ""string ou null"",
                        ""identificacao_talhao"": ""string ou null"",
                        ""nitrogenio_n"": 0.0,
                        ""fosforo_p"": 0.0,
                        ""potassio_k"": 0.0,
                        ""calcio_ca"": 0.0,
                        ""magnesio_mg"": 0.0,
                        ""enxofre_s"": 0.0,
                        ""boro_b"": 0.0,
                        ""cobre_cu"": 0.0,
                        ""ferro_fe"": 0.0,
                        ""manganes_mn"": 0.0,
                        ""zinco_zn"": 0.0
                    }
                ]
            }
            Sua resposta deve conter APENAS o código JSON, sem nenhum texto introdutório, comentários ou explicações adicionais.";
        }
    }

    // Classes auxiliares para deserializar a resposta da API do AI Studio
    internal class GeminiApiResponse
    {
        [JsonPropertyName("candidates")]
        public List<Candidate> Candidates { get; set; } = new();
    }

    internal class Candidate
    {
        [JsonPropertyName("content")]
        public Content Content { get; set; } = new();
    }

    internal class Content
    {
        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; } = new();
    }

    internal class Part
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}

