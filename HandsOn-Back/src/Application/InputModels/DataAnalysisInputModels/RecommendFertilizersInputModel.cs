using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Application.InputModels.DataAnalysisInputModels
{
    public class RecommendFertilizersInputModel
    {
        [Required(ErrorMessage = "Soil recomendation is required.")]
        public bool SoilRecomendation { get; set; }

        [Required(ErrorMessage = "Plots are required.")]
        public List<FertilizerPlotInputModel> Plots { get; set; } = new List<FertilizerPlotInputModel>();
    }

    public class FertilizerPlotInputModel
    {
        [Required(ErrorMessage = "Culture type is required.")]
        [MaxLength(100, ErrorMessage = "Culture cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Culture cannot be empty.")]
        public string? CultureType { get; set; }

        [MaxLength(100, ErrorMessage = "Plot name cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Plot name cannot be empty.")]
        public string? PlotName { get; set; }

        [Required(ErrorMessage = "Expected productivity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Expected productivity cannot be negative")]
        public int ExpectedProductivity { get; set; }

        [Required(ErrorMessage = "Width is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Width cannot be negative")]
        public float Width { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Height cannot be negative")]
        public float Height { get; set; }

        [Required(ErrorMessage = "PRNT is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "PRNT cannot be negative")]
        public float PRNT { get; set; }

        [Required(ErrorMessage = "Leaf inputs are required.")]
        public ICollection<RecomendFertilizerGenericInputModel> Nutrients { get; set; } = [];

    }


    public class RecomendFertilizerGenericInputModel
    {
        [Required(ErrorMessage = "Header is required.")]
        public string Header { get; set; } = string.Empty;

        [Required(ErrorMessage = "Analysis is required.")]
        [MaxLength(100, ErrorMessage = "Analysis cannot be longer than 20 characters.")]
        [MinLength(1, ErrorMessage = "Analysis cannot be empty.")]
        public string Analysis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Value cannot be negative")]
        public float Value { get; set; }
    }
}