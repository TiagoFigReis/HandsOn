using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.FertilizerTableInputModels
{
    public class UpdateFertilizerTableInputModel
    {
        [Range(0, float.MaxValue, ErrorMessage = "Expected bases saturation cannot be negative.")]
        public float ExpectedBasesSaturation { get; set; }

        public UpdateLeafFertilizerRowInputModel LeafFertilizerRow { get; set; } = new();
        public ICollection<UpdateSoilFertilizerRowInputModel> SoilFertilizerRows { get; set; } = [];

        public FertilizerTable ToEntity()
        {
            var tableData = new FertilizerTableData
            {
                LeafFertilizerRow = LeafFertilizerRow.ToEntity(),
                SoilFertilizerRows = SoilFertilizerRows.Select(c => c.ToEntity()).ToList()
            };

            var fertilizerTable = new FertilizerTable
            {
                ExpectedBasesSaturation = ExpectedBasesSaturation
            };

            fertilizerTable.SetTableData(tableData);

            return fertilizerTable;
        }
    }

    public class UpdateLeafFertilizerRowInputModel
    {
        [Required(ErrorMessage = "Leaf Columns are required.")]
        public ICollection<UpdateLeafFertilizerColumnInputModel> LeafFertilizerColumns { get; set; } = [];

        public LeafFertilizerRowData ToEntity()
        {
            return new LeafFertilizerRowData
            {
                LeafFertilizerColumns = LeafFertilizerColumns.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class UpdateSoilFertilizerRowInputModel
    {
        [Range(0, float.MaxValue, ErrorMessage = "Expected productivity cannot be negative")]
        public float ExpectedProductivity { get; set; }

        [Required(ErrorMessage = "Soil Columns are required.")]
        public ICollection<RegisterSoilFertilizerColumnInputModel> SoilFertilizerColumns { get; set; } = [];

        public SoilFertilizerRowData ToEntity()
        {
            return new SoilFertilizerRowData
            {
                ExpectedProductivity = ExpectedProductivity,
                SoilFertilizerColumns = SoilFertilizerColumns.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class UpdateLeafFertilizerColumnInputModel
    {
        [Required(ErrorMessage = "Header is required.")]
        public NutrientHeader Header { get; set; }

        [Required(ErrorMessage = "Products are required.")]
        public ICollection<UpdateLeafFertilizerProductInputModel> Products { get; set; } = [];

        public LeafFertilizerColumnData ToEntity()
        {
            return new LeafFertilizerColumnData
            {
                Header = Header,
                Products = Products.Select(p => p.ToEntity()).ToList()
            };
        }
    }

    public class UpdateLeafFertilizerProductInputModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Min concentration is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Min concentration cannot be negative")]
        public float MinConcentration { get; set; }

        [Required(ErrorMessage = "Max concentration is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Max concentration cannot be negative")]
        public float MaxConcentration { get; set; }

        [Required(ErrorMessage = "Solid is required.")]
        public bool Solid { get; set; }
        public LeafFertilizerProductData ToEntity()
        {
            return new LeafFertilizerProductData
            {
                Name = Name.ToLower(),
                MinConcentration = MinConcentration,
                MaxConcentration = MaxConcentration,
                Solid = Solid
            };
        }
    }

    public class UpdateSoilFertilizerColumnInputModel : IValidatableObject
    {
        [Required(ErrorMessage = "Header is required.")]
        public NutrientHeader Header { get; set; }

        [Required(ErrorMessage = "Number of values is required.")]
        [Range(2, 4, ErrorMessage = "Number of values must be 2, 3 or 4.")]
        public int NumberOfValues { get; set; }

        [Required(ErrorMessage = "Value 1 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Value1 cannot be negative")]
        public float Value1 { get; set; }

        [Required(ErrorMessage = "Value 2 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Value 2 cannot be negative")]
        public float Value2 { get; set; }

        [Required(ErrorMessage = "Value 3 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Value 3 cannot be negative")]
        public float Value3 { get; set; }

        [Required(ErrorMessage = "Value 4 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Value 4 cannot be negative")]
        public float Value4 { get; set; }

        public SoilFertilizerColumnData ToEntity()
        {
            return new SoilFertilizerColumnData
            {
                Header = Header,
                NumberOfValues = NumberOfValues,
                Value1 = Value1,
                Value2 = Value2,
                Value3 = Value3,
                Value4 = Value4
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(Value1 >= Value2 && Value2 >= Value3 && Value3 >= Value4))
            {
                yield return new ValidationResult
                (
                    "Invalid Values: Value1 >= Value2 >= Value3 >= Value4.",
                    new[] { nameof(Value1), nameof(Value2), nameof(Value3), nameof(Value4) }
                );
            }
        }
    }
}