import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { DataAnalyseFacade, DadosAnalise, AnaliseFacade, Plots, RecommendFertilizers, CultureFacade, Culture } from '@farm/core';
import { Column, Row, SelectTable } from '@farm/ui';

@Injectable({
  providedIn: 'root',
})
export class ResultAnaliseComponentFacade {
  private dataAnalyseSubject = new BehaviorSubject<DadosAnalise | null>(null);
  private fertilizersSubject = new BehaviorSubject<RecommendFertilizers | null>(null);
  private analiseSubject = new BehaviorSubject<Row[] | undefined>(undefined);
  private columnsSubject = new BehaviorSubject<Column[] | undefined>(undefined);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private tipoSubject = new BehaviorSubject<number>(0);

  id: string | undefined;
  analise$: Observable<Row[] | undefined> = this.analiseSubject.asObservable();
  columns$: Observable<Column[] | undefined> = this.columnsSubject.asObservable();
  dataAnalyse$: Observable<DadosAnalise | null> = this.dataAnalyseSubject.asObservable();
  fertilizers$: Observable<RecommendFertilizers | null> = this.fertilizersSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  tipo$: Observable<number> = this.tipoSubject.asObservable();

  cultures : Culture[] | undefined = undefined
  standardProductivity = '30'
  standardWidth = '3.5'
  standardHeight = '0.6'

  selectOptions : SelectTable | undefined

  constructor(
    private analiseFacade: AnaliseFacade,
    private dataAnalyseFacade: DataAnalyseFacade,
    private cultureFacade: CultureFacade
  ) {}

  load(data: DadosAnalise) {
    this.dataAnalyseSubject.next(null);
    this.loadingSubject.next(true);

    this.dataAnalyseFacade.AnalyseNutrients(data).pipe(
      tap((dataAnalyse) => {
        this.dataAnalyseSubject.next(dataAnalyse);
        this.loadingSubject.next(false);
      }),
    ).subscribe();
  }

  getCultures(){
    this.cultureFacade.getAllCultures().subscribe(cultures => this.selectOptions = {label: "Selecione uma cultura", options: cultures, optionLabel: "name"})
  }

  recommendFertilizers(data: RecommendFertilizers){
    this.fertilizersSubject.next(null);
    this.loadingSubject.next(true);

    this.dataAnalyseFacade.RecommendFertilizers(data).pipe(
      tap((fertilizers) => {
        this.fertilizersSubject.next(fertilizers);
        this.loadingSubject.next(false);
      }),
    ).subscribe();
  }

  loadAnalyse(id: string | undefined) {
    if (!id) {
      this.id = id;
      return;
    }
    this.id = id;
    this.analiseSubject.next(undefined);
    this.columnsSubject.next(undefined);
    this.loadingSubject.next(true);
    this.tipoSubject.next(0);

    this.analiseFacade.getById(id).pipe(
      tap(
        (analise) => {
          if (analise && analise.dadosAnalise && analise.dadosAnalise.plots) {
            if(analise.tipo == "Foliar"){
              this.tipoSubject.next(1)
            }
            const { rows, columns } = this.transformDataForTable(analise.dadosAnalise.plots, true);
            this.analiseSubject.next(rows);
            this.columnsSubject.next(columns);
          }
          this.loadingSubject.next(false);
        },
        () => {
          this.loadingSubject.next(false);
        },
      ),
    ).subscribe();
  }

  transformDataForTable(plots: Plots[], editable: boolean): { rows: Row[], columns: Column[] } {
    const headerMap = this.getHeaderMap()

    const staticColumns: Column[] = [
      { field: 'plotName', header: 'Talhão', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'cultureType', header: 'Cultura', type: 'select', sortable: true, filterable: true, visible: true, showToUser: true, editable: false },
      { field: 'expectedProductivity', header: 'Produtividade Esperada (sc/ha)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'width', header: 'Espaçamento entre ruas (metros)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'height', header: 'Espaçamento entre plantas (metros)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable }
    ];

    const nutrientHeaders = new Set<string>();

    plots.forEach(plot => {
      plot.nutrients?.forEach(nutrient => {
        if (nutrient.header != null && nutrient.header != undefined ) {
          nutrientHeaders.add(String(nutrient.header));
        }
      });
    });

    const DynamicColumns: Column[] = Array.from(nutrientHeaders)
        .sort((a, b) => Number(a) - Number(b))
        .map(headerKey => {
            const displayHeader = headerMap[headerKey] || headerKey; 
            return {
                field: displayHeader,
                header: displayHeader, 
                type: 'text',
                sortable: true,
                filterable: true,
                visible: true,
                showToUser: true,
                editable: editable
            };
      });

    const rows = plots.map(plot => {
      const cultureTypeOptions = {
          ...this.selectOptions,
          rowIdentifier: plot.plotName 
      };

      const row: Row = {
        plotName: plot.plotName,
        cultureType: cultureTypeOptions,
        expectedProductivity : this.standardProductivity,
        width: this.standardWidth,
        height: this.standardHeight
      };

      plot.nutrients?.forEach(nutrient => {
        if (nutrient.header != null && nutrient.header != undefined ) {
            const headerKey = String(nutrient.header);
            const displayHeader = headerMap[headerKey] || headerKey; 
            const displayValue = `${nutrient.analysis ?? nutrient.value ?? '0'}`;
            row[displayHeader] = displayValue; 
        }
      });

      return row;
    });

    return { rows, columns: [...staticColumns, ...DynamicColumns] };
  }

  getHeaderMap(): { [key: string]: string } {
    if(this.tipoSubject.getValue()){
      return {
        '0': 'N (g/kg)', '1': 'P (g/kg)', '2': 'K (g/kg)', '3': 'Ca (g/kg)',
        '4': 'Mg (g/kg)', '5': 'S (g/kg)', '6': 'Zn (ppm)', '7': 'B (ppm)',
        '8': 'Cu (ppm)', '9': 'Mn (ppm)', '10': 'Fe (ppm)',
      };
    }else{
      return {
        '1': 'P (ppm)', '2': 'K (cmolc/dm³)', '3': 'Ca (cmolc/dm³)', '4': 'Mg (cmolc/dm³)',
        '5': 'S (ppm)', '6': 'Zn (ppm)', '7': 'B (ppm)', '8': 'Cu (ppm)', '9': 'Mn (ppm)',
        '10': 'Fe (ppm)', '24': 'pH H2O', '25': 'Al (cmolc/dm³)', '26': 'H+Al (cmolc/dm³)',
        '27': 'M.O (%)', '28': 'SB (cmolc/dm³)', '29': 'T (cmolc/dm³)', '30': 'v (%)',
      };
    }
  }
}