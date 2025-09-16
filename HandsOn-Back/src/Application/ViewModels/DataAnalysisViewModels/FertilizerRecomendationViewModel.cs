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

        public RecommendationViewModel? Recommendation { get; set; }

        public LeafRecommendationViewModel? LeafRecommendation { get; set; }
    }

    public class RecommendationViewModel
    {
        public DiagnosisSectionViewModel? Diagnosis { get; set; }
        public PlanSectionViewModel? Plan { get; set; }
        public List<NutrientBalanceViewModel> Balance { get; set; } = new();
        public InstallmentViewModel? Installments { get; set; }
    }

    public class DiagnosisSectionViewModel
    {
        public string Description { get; set; } = string.Empty;
        public List<NutrientNeedViewModel> Needs { get; set; } = new();
    }

    public class NutrientNeedViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class PlanSectionViewModel
    {
        public string Description { get; set; } = string.Empty;
        public List<ApplicationStepViewModel> Steps { get; set; } = new();
    }

    public class ApplicationStepViewModel
    {
        public string Title { get; set; } = string.Empty;
        public List<string> Details { get; set; } = new();
    }

    public class NutrientBalanceViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Applied { get; set; } = string.Empty;
        public string Needed { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Balance { get; set; } = string.Empty;
    }

    public class InstallmentViewModel
    {
        public string TotalAnnualDose { get; set; } = string.Empty;
        public int NumberOfInstallments { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<InstallmentDetailViewModel> Details { get; set; } = new();
    }

    public class InstallmentDetailViewModel
    {
        public string FertilizerName { get; set; } = string.Empty;
        public string DosePerInstallment { get; set; } = string.Empty;
    }
    
    public class LeafRecommendationViewModel
{
    public List<CorrectionViewModel> Corrections { get; set; } = new();
}

public class CorrectionViewModel
{
    public string NutrientName { get; set; } = string.Empty;
    public string DiagnosisLevel { get; set; } = string.Empty;
    public string RecommendedActionTitle { get; set; } = string.Empty;
    public List<ProductOptionViewModel> ProductOptions { get; set; } = new();
}

public class ProductOptionViewModel
{
    public string Name { get; set; } = string.Empty;
    public string RecommendationText { get; set; } = string.Empty;
}

}