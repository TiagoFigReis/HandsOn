using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Application.InputModels.DataAnalysisInputModels
{
    public class AnalyseNutrientsInputModel
    {
        [Required(ErrorMessage = "Month is required.")]
        public string? Month { get; set; }

        [Required(ErrorMessage = "Soil analysis is required.")]
        public bool SoilAnalysis { get; set; }

        [Required(ErrorMessage = "Plots are required.")]
        public List<AnalysePlotInputModel> Plots { get; set; } = new List<AnalysePlotInputModel>();
    }

    public class AnalysePlotInputModel
    {
        [Required(ErrorMessage = "Culture type is required.")]
        [MaxLength(100, ErrorMessage = "Culture cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Culture cannot be empty.")]
        public string? CultureType { get; set; }

        [MaxLength(100, ErrorMessage = "Plot name cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Plot name cannot be empty.")]
        public string? PlotName { get; set; }

        public ICollection<AnalyseSingleNutrientInputModel> Nutrients { get; set; } = new List<AnalyseSingleNutrientInputModel>();
    }

    public class AnalyseSingleNutrientInputModel
    {
        [Required(ErrorMessage = "Header is required.")]
        public NutrientHeader Header { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value cannot be negative")]
        public float Value { get; set; }
    }
}