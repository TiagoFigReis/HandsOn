using System.Text.Json.Nodes;
using Core.Enums;

namespace Core.Entities
{
    public class Analise
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Tipo Tipo { get; set; }
        public string Lab { get; set; } = string.Empty;
        public string Proprietario {get; set;} = string.Empty;
        public string Propriedade {get; set;} = string.Empty;
        public DateOnly DataAnalise { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UserId {get; set;}
        public PlotsData? DadosAnalise { get; set; }

        public Analise() { }

        public Analise(Tipo tipo, string lab, string proprietario, string propriedade, DateOnly data, Guid userId)
        {
            Tipo = tipo;
            Lab = lab;
            Proprietario = proprietario;
            Propriedade = propriedade;
            DataAnalise = data;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public void Update(
            string? tipo = null,
            string? lab = null,
            string? proprietario = null,
            string? propriedade = null,
            DateOnly? data = null,
            Guid? userId = null
        )
        {
            Tipo = TipoExtension.ToSource(tipo ?? Tipo.ToFriendlyString());
            Lab = lab ?? Lab;
            Proprietario = proprietario ?? Proprietario;
            Propriedade = propriedade ?? Propriedade;
            DataAnalise = data ?? DataAnalise;
            UserId = userId ?? UserId;
            UpdatedAt = DateTime.Now;
        }
    }
}