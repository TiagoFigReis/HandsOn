import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { DataAnalyseFacade, DadosAnalise, AnaliseFacade, Plots, RecommendFertilizers, CultureFacade, NutrientTableFacade, NutrientTable, Analise } from '@farm/core';
import { Column, Row, Action} from '@farm/ui';
import { LEAF_NUTRIENT_MAP, SOIL_NUTRIENT_MAP, ConfirmationService } from '@farm/core';

@Injectable({
  providedIn: 'root',
})
export class ResultAnaliseComponentFacade {
  private dataAnalyseSubject = new BehaviorSubject<DadosAnalise | null>(null);
  private fertilizersSubject = new BehaviorSubject<RecommendFertilizers | null>(null);
  private analiseSubject = new BehaviorSubject<Row[] | undefined>(undefined);
  private infosAnaliseSubject = new BehaviorSubject<Analise | undefined>(undefined);
  private columnsSubject = new BehaviorSubject<Column[] | undefined>(undefined);
  private nutrientTableSubject = new BehaviorSubject<NutrientTable | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private tipoSubject = new BehaviorSubject<number>(0);

  id: string | undefined;
  nutrientTable$: Observable<NutrientTable | null> = this.nutrientTableSubject.asObservable();
  analise$: Observable<Row[] | undefined> = this.analiseSubject.asObservable();
  infosAnalise$: Observable<Analise | undefined> = this.infosAnaliseSubject.asObservable();
  columns$: Observable<Column[] | undefined> = this.columnsSubject.asObservable();
  dataAnalyse$: Observable<DadosAnalise | null> = this.dataAnalyseSubject.asObservable();
  fertilizers$: Observable<RecommendFertilizers | null> = this.fertilizersSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  tipo$: Observable<number> = this.tipoSubject.asObservable();

  constructor(
    private analiseFacade: AnaliseFacade,
    private dataAnalyseFacade: DataAnalyseFacade,
    private cultureFacade: CultureFacade,
    private nutrientTableFacade: NutrientTableFacade,
    private confirmationService: ConfirmationService,
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

  getNutrientTable(culture: string) {
    this.nutrientTableSubject.next(null);
    this.loadingSubject.next(true);

    this.cultureFacade.getCultureByName(culture).subscribe((c) => {
      if (c && c.id) {
        this.nutrientTableFacade.getNutrientTableByCultureType(c.id).pipe(
          tap((table) => {
            this.nutrientTableSubject.next(table);
            this.loadingSubject.next(false);
          }),
        ).subscribe();
      }
    });
  }

  recommendFertilizers(data: RecommendFertilizers) {
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
    this.infosAnaliseSubject.next(undefined);
    this.columnsSubject.next(undefined);
    this.loadingSubject.next(true);
    this.tipoSubject.next(0);

    this.analiseFacade.getById(id).pipe(
      tap(
        (analise) => {
          if (analise && analise.dadosAnalise && analise.dadosAnalise.plots) {
            if (analise.tipo == "Foliar") {
              this.tipoSubject.next(1);
            }
            this.infosAnaliseSubject.next(analise)
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
    const headerMap = this.getHeaderMap();

    const staticColumns: Column[] = [
      { field: 'plotName', header: 'Talhão', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'expectedProductivity', header: 'Produtividade Esperada (sc/ha)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'width', header: 'Espaçamento entre ruas (metros)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable },
      { field: 'height', header: 'Espaçamento entre plantas (metros)', type: 'text', sortable: true, filterable: true, visible: true, showToUser: true, editable: editable }
    ];

    const nutrientHeaders = new Set<string>();

    plots.forEach(plot => {
      plot.nutrients?.forEach(nutrient => {
        if (nutrient.header != null && nutrient.header != undefined) {
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

    const rows = plots.map((plot, index) => {
      const row: Row = {
        id: index,
        plotName: plot.plotName,
        cultureType: plot.cultureType,
        expectedProductivity: plot.expectedProductivity,
        width: plot.width,
        height: plot.height,
        actions: [
          { tooltip: 'Excluir',
            icon: 'pi pi-fw pi-trash',
            iconClass: 'error',
            command: (event, data) => {
              this.confirmationService.confirm({
                  header: 'Remover Talhão',
                  message: `Deseja remover o talhão da análise ?`,
                  accept: () => {
                    this.deleteRowById(data['id']);
                  },
                });
            },
          },
        ] as Action[],
      };

      plot.nutrients?.forEach(nutrient => {
        if (nutrient.header != null && nutrient.header != undefined) {
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

  deleteRowById(rowId: string) {
    const currentRows = this.analiseSubject.getValue();
    if (!currentRows) {
      return; 
    }

    const updatedRows = currentRows.filter(row => row['id'] !== rowId);

    this.analiseSubject.next(updatedRows);
  }

  updateAnalyse(analise : Analise){
    this.analiseFacade.update(analise).subscribe();
  }

  getHeaderMap(): { [key: string]: string } {
    const activeNutrientMap = this.tipoSubject.getValue() ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;
    return Object.entries(activeNutrientMap).reduce((acc, [key, info]) => {
      acc[key] = info.displayName;
      return acc;
    }, {} as { [key: string]: string });
  }
}