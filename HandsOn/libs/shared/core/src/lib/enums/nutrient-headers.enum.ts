export enum NutrientHeaders {
  N = 'N',
  P = 'P',
  K = 'K',
  Ca = 'Ca',
  Mg = 'Mg',
  S = 'S',
  Zn = 'Zn',
  B = 'B',
  Cu = 'Cu',
  Mn = 'Mn',
  Fe = 'Fe',
  NP = 'N/P',
  NK = 'N/K',
  NS = 'N/S',
  NB = 'N/B',
  NCu = 'N/Cu',
  PMg = 'P/Mg',
  PZn = 'P/Zn',
  KCa = 'K/Ca',
  KMg = 'K/Mg',
  KMn = 'K/Mn',
  CaMg = 'Ca/Mg',
  CaMn = 'Ca/Mn',
  FeMn = 'Fe/Mn',
  phH2O = "pH em Água",
  AlSaturation = 'Saturação por Al',
  PotentialAcidity = 'Acidez Potencial',
  OrganicMatter = 'Matéria Orgânica',
  SumBases = 'Soma de Bases',
  CTCpH7 = 'CTC',
  BasesSaturation = 'Sat. por Bases',
}


export interface NutrientInfo {
  name: string;       
  symbol: string;    
  unit: string;        
  displayName: string; 
}


export enum SoilNutrient {
  P = '1', K = '2', Ca = '3', Mg = '4', S = '5', Zn = '6', B = '7',
  Cu = '8', Mn = '9', Fe = '10', PH_H2O = '24', Al = '25', H_Al = '26',
  MO = '27', SB = '28', T = '29', V = '30',
}

export enum LeafNutrient {
  N = '0', P = '1', K = '2', Ca = '3', Mg = '4', S = '5', Zn = '6',
  B = '7', Cu = '8', Mn = '9', Fe = '10',
}


const createDisplayName = (name: string, symbol: string, unit: string): string => {
  let displayName = name;

  if (name !== symbol && symbol) {
    displayName += ` (${symbol})`;
  }
  if (unit) {
    displayName += ` ${unit}`;
  }
  return displayName;
};


export const SOIL_NUTRIENT_MAP: Readonly<Record<SoilNutrient, NutrientInfo>> = {
  [SoilNutrient.P]: { name: 'Fósforo', symbol: NutrientHeaders.P, unit: 'ppm', displayName: createDisplayName('Fósforo', NutrientHeaders.P, 'ppm') },
  [SoilNutrient.K]: { name: 'Potássio', symbol: NutrientHeaders.K, unit: 'cmolc/dm³', displayName: createDisplayName('Potássio', NutrientHeaders.K, 'cmolc/dm³') },
  [SoilNutrient.Ca]: { name: 'Cálcio', symbol: NutrientHeaders.Ca, unit: 'cmolc/dm³', displayName: createDisplayName('Cálcio', NutrientHeaders.Ca, 'cmolc/dm³') },
  [SoilNutrient.Mg]: { name: 'Magnésio', symbol: NutrientHeaders.Mg, unit: 'cmolc/dm³', displayName: createDisplayName('Magnésio', NutrientHeaders.Mg, 'cmolc/dm³') },
  [SoilNutrient.S]: { name: 'Enxofre', symbol: NutrientHeaders.S, unit: 'ppm', displayName: createDisplayName('Enxofre', NutrientHeaders.S, 'ppm') },
  [SoilNutrient.Zn]: { name: 'Zinco', symbol: NutrientHeaders.Zn, unit: 'ppm', displayName: createDisplayName('Zinco', NutrientHeaders.Zn, 'ppm') },
  [SoilNutrient.B]: { name: 'Boro', symbol: NutrientHeaders.B, unit: 'ppm', displayName: createDisplayName('Boro', NutrientHeaders.B, 'ppm') },
  [SoilNutrient.Cu]: { name: 'Cobre', symbol: NutrientHeaders.Cu, unit: 'ppm', displayName: createDisplayName('Cobre', NutrientHeaders.Cu, 'ppm') },
  [SoilNutrient.Mn]: { name: 'Manganês', symbol: NutrientHeaders.Mn, unit: 'ppm', displayName: createDisplayName('Manganês', NutrientHeaders.Mn, 'ppm') },
  [SoilNutrient.Fe]: { name: 'Ferro', symbol: NutrientHeaders.Fe, unit: 'ppm', displayName: createDisplayName('Ferro', NutrientHeaders.Fe, 'ppm') },
  [SoilNutrient.PH_H2O]: { name: 'pH H2O', symbol: NutrientHeaders.phH2O, unit: '', displayName: createDisplayName(NutrientHeaders.phH2O,'pH H2O', '') },
  [SoilNutrient.Al]: { 
  name: 'Saturação por Al', 
  symbol: 'Al', 
  unit: 'cmolc/dm³', 
  displayName: createDisplayName(NutrientHeaders.AlSaturation, 'Al', 'cmolc/dm³') 
},
[SoilNutrient.H_Al]: { 
  name: 'Acidez Potencial', 
  symbol: 'H+Al', 
  unit: 'cmolc/dm³', 
  displayName: createDisplayName(NutrientHeaders.PotentialAcidity, 'H+Al', 'cmolc/dm³') 
},
[SoilNutrient.MO]: { 
  name: 'Matéria Orgânica', 
  symbol: 'M.O.', 
  unit: '%', 
  displayName: createDisplayName(NutrientHeaders.OrganicMatter, 'M.O.', '%') 
},
[SoilNutrient.SB]: { 
  name: 'Soma de bases', 
  symbol: 'S.B', 
  unit: 'cmolc/dm³', 
  displayName: createDisplayName(NutrientHeaders.SumBases, 'S.B', 'cmolc/dm³') 
},
[SoilNutrient.T]: { 
  name: 'CTC pH 7.0', 
  symbol: 'T', 
  unit: 'cmolc/dm³', 
  displayName: createDisplayName(NutrientHeaders.CTCpH7, 'T', 'cmolc/dm³') 
},
[SoilNutrient.V]: { 
  name: 'Saturação por Bases', 
  symbol: 'V', 
  unit: '%', 
  displayName: createDisplayName(NutrientHeaders.BasesSaturation, 'V', '%') 
},
};


export const LEAF_NUTRIENT_MAP: Readonly<Record<LeafNutrient, NutrientInfo>> = {
  [LeafNutrient.N]: { name: 'Nitrogênio', symbol: NutrientHeaders.N, unit: 'g/kg', displayName: createDisplayName('Nitrogênio', NutrientHeaders.N, 'g/kg') },
  [LeafNutrient.P]: { name: 'Fósforo', symbol: NutrientHeaders.P, unit: 'g/kg', displayName: createDisplayName('Fósforo', NutrientHeaders.P, 'g/kg') },
  [LeafNutrient.K]: { name: 'Potássio', symbol: NutrientHeaders.K, unit: 'g/kg', displayName: createDisplayName('Potássio', NutrientHeaders.K, 'g/kg') },
  [LeafNutrient.Ca]: { name: 'Cálcio', symbol: NutrientHeaders.Ca, unit: 'g/kg', displayName: createDisplayName('Cálcio', NutrientHeaders.Ca, 'g/kg') },
  [LeafNutrient.Mg]: { name: 'Magnésio', symbol: NutrientHeaders.Mg, unit: 'g/kg', displayName: createDisplayName('Magnésio', NutrientHeaders.Mg, 'g/kg') },
  [LeafNutrient.S]: { name: 'Enxofre', symbol: NutrientHeaders.S, unit: 'g/kg', displayName: createDisplayName('Enxofre', NutrientHeaders.S, 'g/kg') },
  [LeafNutrient.Zn]: { name: 'Zinco', symbol: NutrientHeaders.Zn, unit: 'ppm', displayName: createDisplayName('Zinco', NutrientHeaders.Zn, 'ppm') },
  [LeafNutrient.B]: { name: 'Boro', symbol: NutrientHeaders.B, unit: 'ppm', displayName: createDisplayName('Boro', NutrientHeaders.B, 'ppm') },
  [LeafNutrient.Cu]: { name: 'Cobre', symbol: NutrientHeaders.Cu, unit: 'ppm', displayName: createDisplayName('Cobre', NutrientHeaders.Cu, 'ppm') },
  [LeafNutrient.Mn]: { name: 'Manganês', symbol: NutrientHeaders.Mn, unit: 'ppm', displayName: createDisplayName('Manganês', NutrientHeaders.Mn, 'ppm') },
  [LeafNutrient.Fe]: { name: 'Ferro', symbol: NutrientHeaders.Fe, unit: 'ppm', displayName: createDisplayName('Ferro', NutrientHeaders.Fe, 'ppm') },
};