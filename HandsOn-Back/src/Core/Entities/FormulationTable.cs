using System.Text.Json;

namespace Core.Entities
{
    public class FormulationTable
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; }

        public string CompoundFormulationRows { get; set; } = string.Empty;
        public string BasicFormulationRows { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Culture Culture { get; set; } = null!;
        public Guid CultureId { get; set; }

        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public FormulationTable() { }

        public FormulationTable(
            FormulationTableData tableData,
            Culture culture,
            User user
        )
        {
            Id = Guid.NewGuid();

            SetTableData(tableData);

            Culture = culture;
            CultureId = culture.Id;

            User = user;
            UserId = user.Id;
        }

        public void Update(FormulationTableData? tableData = null)
        {
            if (tableData is not null)
                SetTableData(tableData);

            UpdatedAt = DateTime.Now;
        }

        public void SetTableData(FormulationTableData tableData)
        {
            CompoundFormulationRows = JsonSerializer.Serialize(tableData.CompoundFormulationRows);
            BasicFormulationRows = JsonSerializer.Serialize(tableData.BasicFormulationRows);
        }

        public FormulationTableData GetTableData()
        {
            return new FormulationTableData
            {
                CompoundFormulationRows = JsonSerializer.Deserialize<List<FormulationRowData>>(CompoundFormulationRows) ?? new(),
                BasicFormulationRows = JsonSerializer.Deserialize<List<FormulationRowData>>(BasicFormulationRows) ?? new()
            };
        }
    }

    public class FormulationTableData
    {
        public List<FormulationRowData> CompoundFormulationRows { get; set; } = [];
        public List<FormulationRowData> BasicFormulationRows { get; set; } = [];
    }

    public class FormulationRowData
    {
        public List<FormulationColumnData> FormulationColumns { get; set; } = [];
    }

    public class FormulationColumnData
    {
        public float NAmount { get; set; }
        public float PAmount { get; set; }
        public float KAmount { get; set; }
        public float BAmount { get; set; }
    }
}