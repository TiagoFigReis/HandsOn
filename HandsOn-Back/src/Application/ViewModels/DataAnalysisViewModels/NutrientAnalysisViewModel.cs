namespace Application.ViewModels.DataAnalysisViewModels
{
    public class NutrientAnalysisViewModel
    {
        public bool Warning { get; set; }
        public string Month { get; set; } = string.Empty;
        public ICollection<PlotAnalysisViewModel> Plots { get; set; } = new List<PlotAnalysisViewModel>();
    }

    public class PlotAnalysisViewModel
    {
        public string CultureType { get; set; } = string.Empty;
        public string PlotName { get; set; } = string.Empty;

        public int ExpectedProductivity { get; set; } 

        public float Width { get; set; } 

        public float Height { get; set; } 

        public float PRNT { get; set; } 

        public ICollection<SingleNutrientAnalysisViewModel> Nutrients { get; set; } = new List<SingleNutrientAnalysisViewModel>();
    }

    public class SingleNutrientAnalysisViewModel
    {
        public string Header { get; set; } = string.Empty;
        public string Analysis { get; set; } = string.Empty;
        public float Value { get; set; }
    }
}