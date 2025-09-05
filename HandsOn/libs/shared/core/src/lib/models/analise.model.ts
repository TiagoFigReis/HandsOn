export interface Nutrients{
  header: number | string;
  value?: number;
  analysis?: string;
}

export interface ProductRecomendations{
  name: string;
  recomendation: string;
}

export interface Spacing{
  width: number;
  height:number;
}

export interface Plots{
  cultureType?: string;
  plotName?: string
  expectedProductivity?: number
  nutrients?: Nutrients[];
  spacing? : Spacing;
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
  