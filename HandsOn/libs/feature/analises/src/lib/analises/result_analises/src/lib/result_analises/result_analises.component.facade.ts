import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { DataAnalyseFacade, DadosAnalise, AnaliseFacade, Plots, RecommendFertilizers, CultureFacade, NutrientTableFacade, NutrientTable, Analise, LEAF_NUTRIENT_MAP, SOIL_NUTRIENT_MAP } from '@farm/core';

@Injectable({
  providedIn: 'root',
})
export class ResultAnaliseComponentFacade {
  private plotsSubject = new BehaviorSubject<Plots[] | undefined>(undefined);
  private dataAnalyseSubject = new BehaviorSubject<DadosAnalise | null>(null);
  private fertilizersSubject = new BehaviorSubject<RecommendFertilizers | null>(null);
  private infosAnaliseSubject = new BehaviorSubject<Analise | undefined>(undefined);
  private nutrientTableSubject = new BehaviorSubject<NutrientTable | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private tipoSubject = new BehaviorSubject<number>(0);

  id: string | undefined;
  plots$: Observable<Plots[] | undefined> = this.plotsSubject.asObservable();
  nutrientTable$: Observable<NutrientTable | null> = this.nutrientTableSubject.asObservable();
  infosAnalise$: Observable<Analise | undefined> = this.infosAnaliseSubject.asObservable();
  dataAnalyse$: Observable<DadosAnalise | null> = this.dataAnalyseSubject.asObservable();
  fertilizers$: Observable<RecommendFertilizers | null> = this.fertilizersSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  tipo$: Observable<number> = this.tipoSubject.asObservable();

  constructor(
    private analiseFacade: AnaliseFacade,
    private dataAnalyseFacade: DataAnalyseFacade,
    private cultureFacade: CultureFacade,
    private nutrientTableFacade: NutrientTableFacade,
  ) {}

  load(data: DadosAnalise) {
    this.dataAnalyseSubject.next(null);
    this.loadingSubject.next(true);
    this.dataAnalyseFacade.AnalyseNutrients(data).pipe(
      tap((dataAnalyse) => {
        this.dataAnalyseSubject.next(dataAnalyse);
        this.recommendFertilizers({
          soilRecomendation: data.soilAnalysis,
          plots: dataAnalyse.plots
        });
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
      } else {
        this.loadingSubject.next(false);
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
      this.id = undefined;
      return;
    }
    this.id = id;
    this.plotsSubject.next(undefined);
    this.infosAnaliseSubject.next(undefined);
    this.loadingSubject.next(true);
    this.tipoSubject.next(0);

    this.analiseFacade.getById(id).pipe(
      tap(
        (analise) => {
          if (analise && analise.dadosAnalise && analise.dadosAnalise.plots) {
            if (analise.tipo === "Foliar") {
              this.tipoSubject.next(1);
            }
            this.infosAnaliseSubject.next(analise);
            this.plotsSubject.next(analise.dadosAnalise.plots);
          }
          this.loadingSubject.next(false);
        },
        () => {
          this.loadingSubject.next(false);
        },
      ),
    ).subscribe();
  }

  updateAnalyse(analise: Analise){
    this.loadingSubject.next(true);
    this.analiseFacade.update(analise).subscribe({
      next: () => {
        if (analise.dadosAnalise && analise.dadosAnalise.plots !== undefined) {
            this.plotsSubject.next(analise.dadosAnalise.plots);
            this.infosAnaliseSubject.next(analise);
        }
        this.loadingSubject.next(false);
      },
      error: (err) => {
        console.error('Falha ao atualizar a análise', err);
        this.loadingSubject.next(false);
      }
    });
  }

  public getHeaderMap(): { [key: string]: string } {
    const activeNutrientMap = this.tipoSubject.getValue() ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;
    return Object.entries(activeNutrientMap).reduce((acc, [key, info]) => {
      acc[key] = info.displayName;
      return acc;
    }, {} as { [key: string]: string });
  }
}

