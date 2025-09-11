import { NutrientHeaders } from "../enums/nutrient-headers.enum";
import { Culture } from "./culture.model";

export interface NutrientTable {
  id?: string;
  standard: boolean;

  division: string | number;
  leafNutrientRows: NutrientRow[];
  soilNutrientRow: NutrientRow;

  createdAt?: string;
  updatedAt?: string;

  culture?: Culture;
  cultureId: string;
}

export interface NutrientRow {
  nutrientColumns: NutrientColumn[];
}

export interface NutrientColumn {
  header: NutrientHeaders | number;
  inverted: boolean;
  min: number;
  med1: number;
  med2: number;
  max: number;
}