import { NutrientHeaders } from "../enums/nutrient-headers.enum";
import { Culture } from "./culture.model";

export interface FertilizerTable {
  id?: string;
  standard: boolean;
  expectedBasesSaturation: number;

  leafFertilizerRow: LeafFertilizerRow;
  soilFertilizerRows: SoilFertilizerRow[];

  createdAt?: string;
  updatedAt?: string;

  culture?: Culture;
  cultureId: string;
}

export interface LeafFertilizerRow {
  leafFertilizerColumns: LeafFertilizerColumn[];
}

export interface SoilFertilizerRow {
  expectedProductivity: number;
  soilFertilizerColumns: SoilFertilizerColumn[];
}

export interface LeafFertilizerColumn {
  header: NutrientHeaders | number;
  products: LeafFertilizerProduct[];
}

export interface LeafFertilizerProduct {
  name: string;
  solid: boolean;
  minConcentration: number;
  maxConcentration: number;
}

export interface SoilFertilizerColumn {
  header: NutrientHeaders | number;
  numberOfValues: number;
  value1: number;
  value2: number;
  value3: number;
  value4: number;
}