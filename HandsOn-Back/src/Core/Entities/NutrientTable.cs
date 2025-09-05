using System.Text.Json;
using Core.Enums;

namespace Core.Entities
{
    public class NutrientTable
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; } = false;

        public NutrientTableDivision Division { get; set; }
        public string LeafData { get; set; } = string.Empty;
        public string SoilData { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Culture Culture { get; set; } = null!;
        public Guid CultureId { get; set; }

        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public NutrientTable() { }

        public NutrientTable(
            NutrientTableDivision division,
            NutrientTableData tableData,
            Culture culture,
            User user
        )
        {
            Id = Guid.NewGuid();

            Division = division;
            SetTableData(tableData);
            CreatedAt = DateTime.Now;

            Culture = culture;
            CultureId = culture.Id;

            User = user;
            UserId = user.Id;
        }

        public void Update(NutrientTableDivision? division, NutrientTableData? tableData = null)
        {
            Division = division ?? Division;

            if (tableData is not null)
                SetTableData(tableData);

            UpdatedAt = DateTime.Now;
        }

        public void SetTableData(NutrientTableData tableData)
        {
            LeafData = JsonSerializer.Serialize(tableData.LeafNutrientRows);
            SoilData = JsonSerializer.Serialize(tableData.SoilNutrientRow);
        }

        public NutrientTableData GetTableData()
        {
            return new NutrientTableData
            {
                LeafNutrientRows = JsonSerializer.Deserialize<List<NutrientRowData>>(LeafData) ?? new(),
                SoilNutrientRow = JsonSerializer.Deserialize<NutrientRowData>(SoilData) ?? new()
            };
        }
    }

    public class NutrientTableData
    {
        public List<NutrientRowData> LeafNutrientRows { get; set; } = new();
        public NutrientRowData SoilNutrientRow { get; set; } = new();
    }

    public class NutrientRowData
    {
        public List<NutrientColumnData> NutrientColumns { get; set; } = new();
    }

    public class NutrientColumnData
    {
        public NutrientHeader Header { get; set; }
        public bool Inverted { get; set; }
        public float Min { get; set; }
        public float Med1 { get; set; }
        public float Med2 { get; set; }
        public float Max { get; set; }
    }
}