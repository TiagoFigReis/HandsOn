export interface Nutrients{
  header: number | string;
  value?: number;
  analysis?: string;
}

export interface ProductRecomendations{
  name: string;
  recommendation? : Recommendation;
  leafRecommendation? : LeafRecommendation;
}

export interface NutrientNeed {
  name: string;
  value: string;
}

export interface ApplicationStep {
  title: string;
  details: string[];
}

export interface NutrientBalance {
  name: string;
  applied: string;
  needed: string;
  result: string;
  balance: string;
}

export interface InstallmentDetail {
  fertilizerName: string;
  dosePerInstallment: string;
}

export interface Installment {
  totalAnnualDose: string;
  numberOfInstallments: number;
  description: string;
  details: InstallmentDetail[];
}

export interface Recommendation {
  diagnosis: { description: string; needs: NutrientNeed[] };
  plan: { description: string; steps: ApplicationStep[] };
  balance: NutrientBalance[];
  installments?: Installment; 
}

export interface ProductOption {
  name: string;
  recommendationText: string;
}

export interface Correction {
  nutrientName: string;
  diagnosisLevel: string;
  recommendedActionTitle: string;
  productOptions: ProductOption[];
}

export interface Maintenance {
  title: string;
  adequateNutrients: string[]; 
  recommendationText: string;
}

export interface LeafRecommendation {
  corrections: Correction[];
  maintenance?: Maintenance;
}

export interface Plots{
  cultureType?: string;
  plotName?: string
  expectedProductivity?: number;
  width?: number;
  height?: number;
  prnt?: number;
  nutrients?: Nutrients[];
  productRecomendations? : ProductRecomendations[]
}

export interface RecommendFertilizers{
    soilRecomendation?: boolean;
    plots: Plots[]
}

export interface DadosAnalise {
  month?: string;
  soilAnalysis?: boolean;
  plots: Plots[]
}

export interface Analise {
    id?: string;
    tipo?: string;
    lab: string;
    proprietario: string;
    propriedade: string;
    dataAnalise: Date;
    file: File;
    blob?:  Blob;
    createdAt?: string;
    updatedAt?: string;
    dadosAnalise?: DadosAnalise
  }
  