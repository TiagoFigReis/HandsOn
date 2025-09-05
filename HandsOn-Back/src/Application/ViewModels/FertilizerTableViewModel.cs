using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class FertilizerTableViewModel
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; }
        public float ExpectedBasesSaturation { get; set; }

        public LeafFertilizerRowViewModel LeafFertilizerRow { get; set; } = new();
        public ICollection<SoilFertilizerRowViewModel> SoilFertilizerRows { get; set; } = [];

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid CultureId { get; set; }

        public static FertilizerTableViewModel FromEntity(FertilizerTable fertilizerTable)
        {
            var tableData = fertilizerTable.GetTableData();

            return new FertilizerTableViewModel
            {
                Id = fertilizerTable.Id,
                Standard = fertilizerTable.Standard,
                ExpectedBasesSaturation = fertilizerTable.ExpectedBasesSaturation,

                LeafFertilizerRow = LeafFertilizerRowViewModel.FromEntity(tableData.LeafFertilizerRow),

                SoilFertilizerRows = tableData.SoilFertilizerRows
                    .Select(SoilFertilizerRowViewModel.FromEntity)
                    .ToList(),

                CreatedAt = fertilizerTable.CreatedAt,
                UpdatedAt = fertilizerTable.UpdatedAt,

                CultureId = fertilizerTable.CultureId
            };
        }
    }

    public class LeafFertilizerRowViewModel
    {
        public ICollection<LeafFertilizerColumnViewModel> LeafFertilizerColumns { get; set; } = [];

        public static LeafFertilizerRowViewModel FromEntity(LeafFertilizerRowData leafFertilizerRow)
        {
            return new LeafFertilizerRowViewModel
            {
                LeafFertilizerColumns = leafFertilizerRow.LeafFertilizerColumns
                    .Select(LeafFertilizerColumnViewModel.FromEntity)
                    .ToList()
            };
        }
    }

    public class SoilFertilizerRowViewModel
    {
        public float ExpectedProductivity { get; set; }
        public ICollection<SoilFertilizerColumnViewModel> SoilFertilizerColumns { get; set; } = [];

        public static SoilFertilizerRowViewModel FromEntity(SoilFertilizerRowData soilFertilizerRow)
        {
            return new SoilFertilizerRowViewModel
            {
                ExpectedProductivity = soilFertilizerRow.ExpectedProductivity,

                SoilFertilizerColumns = soilFertilizerRow.SoilFertilizerColumns
                    .Select(SoilFertilizerColumnViewModel.FromEntity)
                    .ToList()
            };
        }
    }

    public class LeafFertilizerColumnViewModel
    {
        public string Header { get; set; } = string.Empty;
        public ICollection<LeafFertilizerProductViewModel> Products { get; set; } = [];

        public static LeafFertilizerColumnViewModel FromEntity(LeafFertilizerColumnData leafFertilizerColumn)
        {
            return new LeafFertilizerColumnViewModel
            {
                Header = leafFertilizerColumn.Header.ToFriendlyString(),
                Products = leafFertilizerColumn.Products
                    .Select(LeafFertilizerProductViewModel.FromEntity)
                    .ToList()
            };
        }
    }

    public class LeafFertilizerProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public float MinConcentration { get; set; }
        public float MaxConcentration { get; set; }

        public bool Solid { get; set; }

        public static LeafFertilizerProductViewModel FromEntity(LeafFertilizerProductData leafFertilizerProduct)
        {
            return new LeafFertilizerProductViewModel
            {
                Name = leafFertilizerProduct.Name,
                MinConcentration = leafFertilizerProduct.MinConcentration,
                MaxConcentration = leafFertilizerProduct.MaxConcentration,
                Solid = leafFertilizerProduct.Solid
            };
        }
    }

    public class SoilFertilizerColumnViewModel
    {
        public string Header { get; set; } = string.Empty;
        public int NumberOfValues { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public float Value4 { get; set; }

        public static SoilFertilizerColumnViewModel FromEntity(SoilFertilizerColumnData soilFertilizerColumn)
        {
            return new SoilFertilizerColumnViewModel
            {
                Header = soilFertilizerColumn.Header.ToString(),
                NumberOfValues = soilFertilizerColumn.NumberOfValues,
                Value1 = soilFertilizerColumn.Value1,
                Value2 = soilFertilizerColumn.Value2,
                Value3 = soilFertilizerColumn.Value3,
                Value4 = soilFertilizerColumn.Value4
            };
        }
    }
}