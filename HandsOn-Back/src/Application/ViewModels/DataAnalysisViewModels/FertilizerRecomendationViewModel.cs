namespace Application.ViewModels.DataAnalysisViewModels
{
    public class FertilizerRecomendationViewModel
    {
        public bool SoilRecomendation { get; set; }
        public ICollection<PlotFertilizerViewModel> Plots { get; set; } = new List<PlotFertilizerViewModel>();
    }

    public class PlotFertilizerViewModel
    {
        public string CultureType { get; set; } = string.Empty;
        public string PlotName { get; set; } = string.Empty;
        public ICollection<ProductRecomendationViewModel> ProductRecomendations { get; set; } = [];
    }

    public class ProductRecomendationViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Recomendation { get; set; } = string.Empty;
    }
}