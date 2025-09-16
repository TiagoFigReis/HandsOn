using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.InputModels.InputModelsAnalise
{
    public class AnaliseInputModel
    {
        [Required(ErrorMessage = "É necessário que a análise tenha um laboratório")]
        [MaxLength(100, ErrorMessage = "Laboratório não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Laboratório deve ter pelo menos 1 caracter")]
        public string Lab { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessario um tipo de análise")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário um proprietário")]
        [MaxLength(100, ErrorMessage = "Proprietário não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Proprietário deve ter pelo menos 1 caracter")]
        public string Proprietario { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário uma propriedade")]
        [MaxLength(100, ErrorMessage = "Propriedade não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Propriedade deve ter pelo menos 1 caracter")]
        public string Propriedade { get; set; } = string.Empty;
        [Required(ErrorMessage = "É necessário uma data em que a amostra foi retirada")]
        public DateOnly DataAnalise { get; set; }

        public string? DadosAnalise { get; set; }
        
        public IFormFile? Analise { get; set; }

    }
}