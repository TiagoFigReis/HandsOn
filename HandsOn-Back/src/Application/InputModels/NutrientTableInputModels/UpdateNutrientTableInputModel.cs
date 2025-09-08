using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.NutrientTableInputModels
{
    public class UpdateNutrientTableInputModel
    {
        public NutrientTableDivision Division { get; set; }
        public ICollection<UpdateNutrientRowInputModel> LeafNutrientRows { get; set; } = [];
        public UpdateNutrientRowInputModel SoilNutrientRow { get; set; } = new();

        public NutrientTable ToEntity()
        {
            var tableData = new NutrientTableData
            {
                LeafNutrientRows = LeafNutrientRows!.Select(row => row.ToEntity()).ToList(),
                SoilNutrientRow = SoilNutrientRow.ToEntity()
            };

            var nutrientTable = new NutrientTable
            {
                Division = Division!
            };

            nutrientTable.SetTableData(tableData);

            return nutrientTable;
        }
    }

    public class UpdateNutrientRowInputModel
    {
        [Required(ErrorMessage = "Nutrient columns are required")]
        public ICollection<UpdateNutrientColumnInputModel> NutrientColumns { get; set; } = [];

        public NutrientRowData ToEntity()
        {
            return new NutrientRowData
            {
                NutrientColumns = NutrientColumns!.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class UpdateNutrientColumnInputModel : IValidatableObject
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
                if (Inverted)
                {
                    if (!(Min > Med1 && Med1 > Med2 && Med2 > Max))
                    {
                        yield return new ValidationResult
                        (
                            "Invalid Values: Min > Med1 > Med2 > Max.",
                            new[] { nameof(Min), nameof(Med1), nameof(Med2), nameof(Max) }
                        );
                    }
                }
                else
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