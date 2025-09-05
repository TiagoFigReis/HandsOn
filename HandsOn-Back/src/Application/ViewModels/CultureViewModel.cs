using Core.Entities;

namespace Application.ViewModels
{
    public class CultureViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static CultureViewModel FromEntity(Culture culture)
        {
            return new CultureViewModel
            {
                Id = culture.Id,
                Name = culture.Name,
                NormalizedName = culture.NormalizedName,
                CreatedAt = culture.CreatedAt,
                UpdatedAt = culture.UpdatedAt
            };
        }
    }
}