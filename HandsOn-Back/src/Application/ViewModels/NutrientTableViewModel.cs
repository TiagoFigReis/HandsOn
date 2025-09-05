using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class NutrientTableViewModel
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; }

        public string Division { get; set; } = string.Empty;
        public ICollection<NutrientRowViewModel> LeafNutrientRows { get; set; } = [];
        public NutrientRowViewModel SoilNutrientRow { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid CultureId { get; set; }

        public static NutrientTableViewModel FromEntity(NutrientTable nutrientTable)
        {
            var tableData = nutrientTable.GetTableData();

            return new NutrientTableViewModel
            {
                Id = nutrientTable.Id,
                Standard = nutrientTable.Standard,

                Division = nutrientTable.Division.ToFriendlyString(),

                LeafNutrientRows = tableData.LeafNutrientRows
                    .Select(NutrientRowViewModel.FromEntity)
                    .ToList(),

                SoilNutrientRow = NutrientRowViewModel.FromEntity(tableData.SoilNutrientRow),

                CreatedAt = nutrientTable.CreatedAt,
                UpdatedAt = nutrientTable.UpdatedAt,

                CultureId = nutrientTable.CultureId
            };
        }
    }

    public class NutrientRowViewModel
    {
        public ICollection<NutrientColumnViewModel> NutrientColumns { get; set; } = [];

        public static NutrientRowViewModel FromEntity(NutrientRowData nutrientRow)
        {
            return new NutrientRowViewModel
            {
                NutrientColumns = nutrientRow.NutrientColumns
                    .Select(NutrientColumnViewModel.FromEntity)
                    .ToList()
            };
        }
    }

    public class NutrientColumnViewModel
    {
        public string Header { get; set; } = string.Empty;
        public bool Inverted { get; set; }
        public float Min { get; set; }  
        public float Med1 { get; set; }
        public float Med2 { get; set; }
        public float Max { get; set; }

        public static NutrientColumnViewModel FromEntity(NutrientColumnData nutrientColumn)
        {
            return new NutrientColumnViewModel
            {
                Header = nutrientColumn.Header.ToFriendlyString(),
                Inverted = nutrientColumn.Inverted,
                Min = nutrientColumn.Min,
                Med1 = nutrientColumn.Med1,
                Med2 = nutrientColumn.Med2,
                Max = nutrientColumn.Max
            };
        }
    }
}