using System.Text.Json;
using Core.Enums;

namespace Core.Entities
{
    public class FertilizerTable
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; } = false;
        public float ExpectedBasesSaturation { get; set; }

        public string LeafParameters { get; set; } = string.Empty;
        public string SoilParameters { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Culture Culture { get; set; } = null!;
        public Guid CultureId { get; set; }

        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public FertilizerTable() { }

        public FertilizerTable(
            FertilizerTableData tableData,
            Culture culture,
            User user
        )
        {
            Id = new Guid();

            SetTableData(tableData);
            CreatedAt = DateTime.Now;

            Culture = culture;
            CultureId = culture.Id;

            User = user;
            UserId = user.Id;
        }

        public void Update(FertilizerTableData? tableData = null)
        {
            if (tableData is not null)
                SetTableData(tableData);

            UpdatedAt = DateTime.Now;
        }

        public void SetTableData(FertilizerTableData tableData)
        {
            LeafParameters = JsonSerializer.Serialize(tableData.LeafFertilizerRow);
            SoilParameters = JsonSerializer.Serialize(tableData.SoilFertilizerRows);
        }

        public FertilizerTableData GetTableData()
        {
            return new FertilizerTableData
            {
                LeafFertilizerRow = JsonSerializer.Deserialize<LeafFertilizerRowData>(LeafParameters) ?? new(),
                SoilFertilizerRows = JsonSerializer.Deserialize<List<SoilFertilizerRowData>>(SoilParameters) ?? []
            };
        }
    }

    public class FertilizerTableData
    {
        public LeafFertilizerRowData LeafFertilizerRow = new();
        public List<SoilFertilizerRowData> SoilFertilizerRows = [];
    }

    public class LeafFertilizerRowData
    {
        public List<LeafFertilizerColumnData> LeafFertilizerColumns { get; set; } = [];
    }

    public class SoilFertilizerRowData
    {
        public float ExpectedProductivity { get; set; }
        public List<SoilFertilizerColumnData> SoilFertilizerColumns { get; set; } = [];
    }

    public class LeafFertilizerColumnData
    {
        public NutrientHeader Header { get; set; }
        public List<LeafFertilizerProductData> Products { get; set; } = [];
    }

    public class LeafFertilizerProductData
    {
        public string Name { get; set; } = string.Empty;
        public bool Solid { get; set; }
        public float MinConcentration { get; set; }
        public float MaxConcentration { get; set; }
    }

    public class SoilFertilizerColumnData
    {
        public NutrientHeader Header { get; set; }
        public int NumberOfValues { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public float Value4 { get; set; }
    }
}