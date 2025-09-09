import { Culture } from "./culture.model";

export interface FormulationTable {
    id?: string;
    standard: boolean;

    compoundFormulationRows: FormulationRow[];
    basicFormulationRows: FormulationRow[];

    createdAt?: string;
    updatedAt?: string;

    culture?: Culture;
    cultureId: string;
}

export interface FormulationRow {
    formulationColumns: FormulationColumn[];
}

export interface FormulationColumn {
    nAmount: number;
    pAmount: number;
    kAmount: number;
    bAmount: number;
}