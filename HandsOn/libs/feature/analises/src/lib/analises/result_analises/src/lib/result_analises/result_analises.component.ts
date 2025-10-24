import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Analise, DadosAnalise, Nutrients, RecommendFertilizers, NutrientTable, Plots, LEAF_NUTRIENT_MAP, SOIL_NUTRIENT_MAP } from '@farm/core';
import { FormsModule } from '@angular/forms';
import { ResultAnaliseComponentFacade } from './result_analises.component.facade';
import { SpinnerComponent } from '@farm/ui';
import { filter, take } from 'rxjs/operators';
import { BarChartComponent } from '@farm/ui';
import { RecommendationDisplayComponent } from './recommendation-display/recommendation-display.component';
import { LeafRecommendationDisplayComponent } from './leaf-recommendation-display/leaf-recommendation-display.component';
import { ConfirmationService } from '@farm/core';
import { NotificationService } from '@farm/core';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

export type NutrientAnalysis = any;

@Component({
  selector: 'lib-result-analises',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    SpinnerComponent,
    BarChartComponent,
    RecommendationDisplayComponent,
    LeafRecommendationDisplayComponent,
    ConfirmDialogModule,
  ],
  templateUrl: './result_analises.component.html',
})
export class ResultAnalisesComponent implements OnInit {
  id: string | undefined = undefined;
  loading = true;
  analise: Analise | undefined;
  allPlots: Plots[] = [];
  selectedPlot: Plots | undefined;
  activeTab: 'analise' | 'recomendacao' = 'analise';
  editableNutrientData: NutrientAnalysis[] = [];
  fertilizerRecommendations: RecommendFertilizers | undefined;
  table: NutrientTable | undefined;
  tipo = 0; 

  constructor(
    private route: ActivatedRoute,
    public dataAnalyseFacade: ResultAnaliseComponentFacade,
    private confirmationService: ConfirmationService,
    private notificationService : NotificationService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;
    if (!this.id) {
      this.loading = false;
      return;
    }

    this.dataAnalyseFacade.loadAnalyse(this.id);

    this.dataAnalyseFacade.plots$.subscribe((plots) => {
      if (plots) {
        this.allPlots = plots;
        if (!this.selectedPlot || !this.allPlots.some(p => p.plotName === this.selectedPlot?.plotName)) {
            this.selectPlot(this.allPlots.length > 0 ? this.allPlots[0] : undefined);
        }
      }
    });

    this.dataAnalyseFacade.infosAnalise$.subscribe(analise => {
      if (analise) this.analise = analise;
    });

    this.dataAnalyseFacade.tipo$.subscribe(tipo => this.tipo = tipo);
    this.dataAnalyseFacade.loading$.subscribe(loading => this.loading = loading);

    this.dataAnalyseFacade.fertilizers$.subscribe(fertilizers => {
      if (fertilizers) {
        this.fertilizerRecommendations = fertilizers;
        this.setActiveTab('recomendacao');
      }
    });

    this.dataAnalyseFacade.nutrientTable$.subscribe(table => {
      if (table) this.table = table;
    });
  }

  onNutrientValueChange(updatedNutrient: NutrientAnalysis) {
    const index = this.editableNutrientData.findIndex(n => n.name === updatedNutrient.name);
    if (index !== -1) {
      this.editableNutrientData[index] = updatedNutrient;
    }
    if (this.selectedPlot && this.selectedPlot.nutrients) {
      const activeNutrientMap = this.tipo === 1 ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;
      const nutrientEntry = Object.entries(activeNutrientMap).find(([, info]) => {
        const cleanedName = info.displayName.replace(/\s+[A-Za-z%µ/²³]+$/, "");
        return cleanedName === updatedNutrient.name;
      });
      if (nutrientEntry) {
        const nutrientKey = nutrientEntry[0];
        const nutrientInPlot = this.selectedPlot.nutrients.find(n => n.header == nutrientKey);
        if (nutrientInPlot) {
          nutrientInPlot.value = Number(updatedNutrient.value);
        }
      }
    }
  }

  solicitar_recomendacoes() {
    if (!this.selectedPlot) return;
    const dadosAnalise: DadosAnalise = {
      month: '-',
      soilAnalysis: this.tipo === 0,
      plots: [this.selectedPlot]
    };
    this.dataAnalyseFacade.load(dadosAnalise);
  }
  
  selectPlot(plot: Plots | undefined) {
    if(plot){
      this.selectedPlot = JSON.parse(JSON.stringify(plot));
      this.fertilizerRecommendations = undefined;
      this.activeTab = 'analise';
      if (plot.cultureType) {
        this.dataAnalyseFacade.getNutrientTable(plot.cultureType);
        this.dataAnalyseFacade.nutrientTable$.pipe(filter(table => !!table), take(1))
          .subscribe(table => {
            this.table = table;
            if (this.selectedPlot) {
              this.editableNutrientData = this.mapDataForCharts(this.selectedPlot);
            }
          });
      }
    } else {
      this.selectedPlot = undefined;
    }
  }

  setActiveTab(tab: 'analise' | 'recomendacao') {
    this.activeTab = tab;
  }

  onSave() {
    this.confirmationService.confirm({
        message: 'Tem certeza que deseja salvar as alterações?',
        header: 'Confirmação de Salvamento',
        accept: () => {
            if (this.analise && this.analise.dadosAnalise && this.selectedPlot) {
                const plotIndex = this.allPlots.findIndex(p => p.plotName === this.selectedPlot?.plotName);
                if (plotIndex !== -1) {
                    const updatedPlots = [...this.allPlots];
                    updatedPlots[plotIndex] = this.selectedPlot;
                    const updatedAnalise = { 
                      ...this.analise, 
                      dadosAnalise: { ...this.analise.dadosAnalise, plots: updatedPlots }
                    };
                    this.dataAnalyseFacade.updateAnalyse(updatedAnalise);
                }
            }
        },
    });
  }

  onDeletePlot() {
    console.log(this.allPlots.length)
    if(this.allPlots.length == 1) {
      this.notificationService.error(
              'Erro!',
              'Não é possível excluir todos os talhões de uma análise!',
            );
      return;
    }
    this.confirmationService.confirm({
        message: `Tem certeza que deseja excluir o talhão "${this.selectedPlot?.plotName}"? Esta ação não pode ser desfeita.`,
        header: 'Confirmação de Exclusão',
        accept: () => {
            if (this.analise && this.analise.dadosAnalise && this.selectedPlot) {
                const updatedPlots = this.allPlots.filter(p => p.plotName !== this.selectedPlot?.plotName);
                const updatedAnalise = {
                  ...this.analise,
                  dadosAnalise: { ...this.analise.dadosAnalise, plots: updatedPlots }
                };
                this.dataAnalyseFacade.updateAnalyse(updatedAnalise);
            }
        },
    });
  }

  mapDataForCharts(plot: Plots): NutrientAnalysis[] {
    if (!this.table) return [];
    let nutrientDefs;
    if (this.tipo === 0 && this.table.soilNutrientRow) {
        nutrientDefs = this.table.soilNutrientRow.nutrientColumns;
    } else if (this.tipo === 1 && this.table.leafNutrientRows?.length) {
        nutrientDefs = this.table.leafNutrientRows[0].nutrientColumns;
    }
    return nutrientDefs ? this.transformNutrients(plot.nutrients || [], nutrientDefs) : [];
  }

  private transformNutrients(measuredValues: Nutrients[], rangeDefs: any[]): NutrientAnalysis[] {
    const chartData: NutrientAnalysis[] = [];
    const activeNutrientMap = this.tipo ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;
    for (const [key, info] of Object.entries(activeNutrientMap)) {
      if (info.name.includes('/')) continue;
      const measured = measuredValues.find(m => m.header == key);
      const rangeDef = rangeDefs.find(r => r.header === info.symbol || r.header === info.name);
      if (measured && measured.value != null && rangeDef) {
        const min = parseFloat(rangeDef.min.toFixed(2));
        const max = parseFloat(rangeDef.max.toFixed(2));
        const inverted = !!rangeDef.inverted;
        const clear = (str: string) => str.replace(/\s+[A-Za-z%µ/²³]+$/, "");
        const scaleMax = max > 0 ? parseFloat((max * 1.3).toFixed(2)) : parseFloat((min * 1.3).toFixed(2)) || 1;
        const value = measured.analysis ? parseFloat(measured.analysis) : measured.value;
        let dataPoint: NutrientAnalysis = {
            name: clear(info.displayName), value: value, unit: info.unit, inverted: inverted,
            veryLowMin: 0, scaleMax: scaleMax,
        };
        if (rangeDef.med1 && rangeDef.med2) {
            const med1 = parseFloat(rangeDef.med1.toFixed(2));
            const med2 = parseFloat(rangeDef.med2.toFixed(2));
            dataPoint = { ...dataPoint, isSimpleRange: false, ranges: {
                veryLow:  { min: 0, max: min },
                low:      { min: min, max: med1 },
                medium:   { min: med1, max: med2 },
                good:     { min: med2, max: max },
                veryGood: { min: max, max: scaleMax },
            }};
        } else {
            const midpoint = parseFloat(((min + max) / 2).toFixed(2));
            dataPoint = { ...dataPoint, isSimpleRange: true, ranges: {
                low:      { min: 0, max: min },
                medium:   { min: min, max: midpoint },
                adequate: { min: midpoint, max: max },
                high:     { min: max, max: scaleMax },
            }};
        }
        chartData.push(dataPoint);
      }
    }
    return chartData;
  }

  trackByName(index: number, item: NutrientAnalysis): string {
    return item.name;
  }
}

