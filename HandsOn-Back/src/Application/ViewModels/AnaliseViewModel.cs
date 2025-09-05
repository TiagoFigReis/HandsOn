using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class AnaliseViewModel
    {
        public Guid Id {get; set;}
        public string? Tipo { get; set; }
        public string? Lab {get; set;}
        public string? Propriedade { get; set; }
        public string? Proprietario {get; set;}
        public DateOnly DataAnalise {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId {get; set;}

        public PlotsData? DadosAnalise { get; set; }

        public static AnaliseViewModel FromEntity(Analise analise)
        {
            return new AnaliseViewModel
            {
                Id = analise.Id,
                Tipo = TipoExtension.ToFriendlyString(analise.Tipo),
                Lab = analise.Lab,
                Propriedade = analise.Propriedade,
                Proprietario = analise.Proprietario,
                DataAnalise = analise.DataAnalise,
                CreatedAt = analise.CreatedAt,
                UpdatedAt = analise.UpdatedAt,
                UserId = analise.UserId,
                DadosAnalise = analise.DadosAnalise
            };
        }
    }
}