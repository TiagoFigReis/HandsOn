using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.NutrientTableInputModels
{
    public class RegisterNutrientTableInputModel
    {
        [Required(ErrorMessage = "Nutrient table division is required.")]
        public NutrientTableDivision Division { get; set; }

        [Required(ErrorMessage = "Leaf nutrient rows are required.")]
        public ICollection<RegisterNutrientRowInputModel> LeafNutrientRows { get; set; } = [];

        [Required(ErrorMessage = "Soil nutrient row is required.")]
        public RegisterNutrientRowInputModel SoilNutrientRow { get; set; } = new();

        [Required(ErrorMessage = "Culture is required.")]
        public Guid CultureId { get; set; }

        public NutrientTable ToEntity()
        {
            var tableData = new NutrientTableData
            {
                LeafNutrientRows = LeafNutrientRows.Select(r => r.ToEntity()).ToList(),
                SoilNutrientRow = SoilNutrientRow.ToEntity()
            };

            var nutrientTable = new NutrientTable
            {
                Id = Guid.NewGuid(),
                Division = Division,
                CreatedAt = DateTime.Now
            };

            nutrientTable.SetTableData(tableData);

            return nutrientTable;
        }
    }

    public class RegisterNutrientRowInputModel
    {

        [Required(ErrorMessage = "Nutrient columns are required")]
        public ICollection<RegisterNutrientColumnInputModel> NutrientColumns { get; set; } = [];

        public NutrientRowData ToEntity()
        {
            return new NutrientRowData
            {
                NutrientColumns = NutrientColumns.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class RegisterNutrientColumnInputModel : IValidatableObject
    {
        [Required(ErrorMessage = "Header is required.")]
        public NutrientHeader Header { get; set; }

        [Required(ErrorMessage = "Inverted is required.")]
        public bool Inverted { get; set; }

        [Required(ErrorMessage = "Min is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Min cannot be negative")]
        public float Min { get; set; }

        [Required(ErrorMessage = "Med1 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Min cannot be negative")]
        public float Med1 { get; set; }

        [Required(ErrorMessage = "Med2 is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Min cannot be negative")]
        public float Med2 { get; set; }

        [Required(ErrorMessage = "Max is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Max cannot be negative")]
        public float Max { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Med1 != 0 && Med2 != 0)
            {
                
                if (!(Min < Med1 && Med1 < Med2 && Med2 < Max))
                {
                    yield return new ValidationResult
                    (
                        "Invalid Values: Min < Med1 < Med2 < Max.",
                        new[] { nameof(Min), nameof(Med1), nameof(Med2), nameof(Max) }
                    );
                }
            }

            else if (Min >= Max)
            {
                yield return new ValidationResult
                (
                    "Max must be greater than Min",
                    new[] { nameof(Max), nameof(Min) }
                );
            }
        }

        public NutrientColumnData ToEntity()
        {
            return new NutrientColumnData
            {
                Header = Header,
                Inverted = Inverted,
                Min = Min,
                Med1 = Med1,
                Med2 = Med2,
                Max = Max
            };
        }
    }
}
