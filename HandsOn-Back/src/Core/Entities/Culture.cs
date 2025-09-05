namespace Core.Entities
{
    public class Culture
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Culture() { }

        public Culture(string name, string normalizedName)
        {
            Id = Guid.NewGuid();
            Name = name;
            NormalizedName = normalizedName;

            CreatedAt = DateTime.Now;
        }

        public void Update(string? name = null, string? normalizedName = null)
        {
            Name = name ?? Name;
            NormalizedName = normalizedName ?? NormalizedName;

            UpdatedAt = DateTime.Now;
        }
    }
}