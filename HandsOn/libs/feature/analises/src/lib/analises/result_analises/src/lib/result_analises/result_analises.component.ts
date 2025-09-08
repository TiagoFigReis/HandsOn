import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Analise, DadosAnalise, Nutrients, RecommendFertilizers, ProductRecomendations, Spacing, NutrientTable } from '@farm/core';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { TableModule } from 'primeng/table';
import { CardModule } from 'primeng/card';
import { ResultAnaliseComponentFacade } from './result_analises.component.facade';
import { Column, Row, TableComponent, ButtonComponent, SpinnerComponent, selectedOption, NutrientAnalysis } from '@farm/ui';
import { filter, map, switchMap } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { AccordionModule } from 'primeng/accordion';
import { BarChartComponent } from '@farm/ui';
import { LEAF_NUTRIENT_MAP, SOIL_NUTRIENT_MAP, NutrientInfo } from '@farm/core';

@Component({
  selector: 'lib-result-analises',
  imports: [CommonModule, TableModule, CardModule, ButtonComponent, InputNumberModule, InputTextModule, FormsModule, SpinnerComponent, RouterModule, TableComponent, AccordionModule, BarChartComponent],
  templateUrl: './result_analises.component.html',
  styleUrl: './result_analises.component.css',
})
export class ResultAnalisesComponent implements OnInit {
  id: string | undefined = undefined;
  loading = true;
  formData = new FormData();
  tipoAnalise = 0;
  resultsData: DadosAnalise | null = null;
  showMoreButton = false;
  analise: Analise | undefined;
  data: Row[] = [];
  columns: Column[] = [];
  editable = true;
  tipo = 0;
  fertilizerRecommendations: RecommendFertilizers | undefined;
  table: NutrientTable | undefined;
  cultureError = false;
  leafChartData: NutrientAnalysis[] = [];
  soilChartData: NutrientAnalysis[] = [];
  plotCulture: Record<string, string> = {};

  constructor(
    private route: ActivatedRoute,
    private dataAnalyseFacade: ResultAnaliseComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;
    if (!this.id) {
      this.loading = false;
      return;
    }

    this.dataAnalyseFacade.getCultures().pipe(
      switchMap(() => {
        this.dataAnalyseFacade.loadAnalyse(this.id);
        return this.dataAnalyseFacade.analise$;
      })
    ).subscribe((analiseData) => {
      if (analiseData) {
        this.data = analiseData;
      }
    });

    this.dataAnalyseFacade.tipo$.subscribe((tipo) => {
      this.tipo = tipo;
    });

    this.dataAnalyseFacade.columns$.subscribe((cols) => {
      if (cols) {
        this.columns = cols;
      }
    });

    this.dataAnalyseFacade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  private mapDataForCharts(): void {
    if (!this.resultsData?.plots?.length || !this.table) {
      return;
    }
    const plotData = this.resultsData.plots[0];
    if (this.tipo === 0 && this.table.soilNutrientRow) {
      this.soilChartData = this.transformNutrients(plotData.nutrients || [], this.table.soilNutrientRow.nutrientColumns);
    } else if (this.tipo === 1 && this.table.leafNutrientRows?.length) {
      this.leafChartData = this.transformNutrients(plotData.nutrients || [], this.table.leafNutrientRows[0].nutrientColumns);
    }
  }

  private transformNutrients(measuredValues: Nutrients[], rangeDefs: any[]): NutrientAnalysis[] {
    const chartData: NutrientAnalysis[] = [];
    const activeNutrientMap = this.tipo ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;

    for (const info of Object.values(activeNutrientMap)) {
      if (info.name.includes('/')) continue;

      const measured = measuredValues.find(m => {
        return m.header === info.displayName || m.header === info.name
      });
      const rangeDef = rangeDefs.find(r => {
        return r.header === info.symbol || r.header === info.name
      });

      if (measured && measured.value && rangeDef) {
        const lowMax = parseFloat(rangeDef.min.toFixed(2));
        const mediumMax = parseFloat((rangeDef.med1 !== 0 ? rangeDef.med1 : (rangeDef.min + rangeDef.max) / 2).toFixed(2));
        const adequateMax = parseFloat((rangeDef.med2 !== 0 ? rangeDef.med2 : rangeDef.max).toFixed(2));
        const highMin = adequateMax;
        const scaleMaximum = parseFloat((adequateMax * 1.3).toFixed(2));

        chartData.push({
          name: `${info.name} (${info.symbol})`,
          value: measured.value,
          unit: info.unit,
          ranges: {
            low: { min: 0, max: lowMax },
            medium: { min: lowMax, max: mediumMax },
            adequate: { min: mediumMax, max: adequateMax },
            high: { min: highMin, max: scaleMaximum },
          },
          scaleMax: scaleMaximum
        });
      }
    }
    return chartData;
  }

  selectedOption(selectedOption: selectedOption) {
    this.plotCulture[selectedOption.identifier] = selectedOption.selectedOption;
  }

  refresh() {
    this.dataAnalyseFacade.loadAnalyse(this.id);
  }

  solicitar_recomendacoes() {
    if (this.data.length !== Object.keys(this.plotCulture).length) {
      this.cultureError = true;
      return;
    }
    this.cultureError = false;
    const activeNutrientMap = this.tipo ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;

    const plotsForAnalysis = this.data.map((item) => {
      const nutrients = Object.entries(activeNutrientMap).map(([nutrientCode, info]) => {
        const value = Number(item[info.displayName]) || 0;
        return { header: Number(nutrientCode), value: value };
      });
      return {
        plotName: item['plotName']?.toString() || '',
        cultureType: this.plotCulture[item['plotName']],
        nutrients
      };
    });

    const dadosAnalise = {
      month: '-',
      soilAnalysis: !this.tipo,
      plots: plotsForAnalysis
    };

    this.dataAnalyseFacade.load(dadosAnalise as DadosAnalise);

    this.dataAnalyseFacade.dataAnalyse$.pipe(
      filter(dataAnalyse => !!dataAnalyse?.plots),
      switchMap(dataAnalyse => {
        if (!dataAnalyse) return EMPTY;
        const cultureType = dataAnalyse.plots[0]?.cultureType;
        if (!cultureType) return EMPTY;
        this.dataAnalyseFacade.getNutrientTable(cultureType);
        return this.dataAnalyseFacade.nutrientTable$.pipe(
          filter(table => !!table),
          map(table => ({ dataAnalyse, table }))
        );
      }),
      switchMap(({ dataAnalyse, table }) => {
        this.table = table;

        const symbolToInfoMap = new Map<string, NutrientInfo>(
            Object.values(activeNutrientMap).map(info => [info.symbol, info])
        );

        const plotsWithMappedNutrients = dataAnalyse.plots.map((item) => {
          const nutrients: Nutrients[] = item.nutrients?.map(n => {
            const info = symbolToInfoMap.get(String(n.header));
            return { ...n, header: info ? info.displayName : String(n.header) };
          }) || [];
          return {
            plotName: item['plotName']?.toString() || '',
            cultureType: item['cultureType']?.toString() || '',
            nutrients
          };
        });

        const productivityMap = new Map<string, number>();
        this.data.forEach(row => {
          productivityMap.set(row['plotName']?.toString() || '', Number(row['expectedProductivity']) || 0);
        });

        const spacingMap = new Map<string, Spacing>();
        this.data.forEach(row => {
          spacingMap.set(row['plotName']?.toString() || '', { width: Number(row['width']), height: Number(row['height']) });
        });

        const finalPlots = dataAnalyse.plots.map(plot => ({
          ...plot,
          expectedProductivity: productivityMap.get(plot.plotName || '') || 0,
          spacing: spacingMap.get(plot.plotName || '')
        }));

        this.resultsData = { ...dataAnalyse, plots: plotsWithMappedNutrients };

        const fertilizersPayload: RecommendFertilizers = {
          soilRecomendation: !this.tipo,
          plots: finalPlots
        };

        this.dataAnalyseFacade.recommendFertilizers(fertilizersPayload);
        return this.dataAnalyseFacade.fertilizers$;
      })
    ).subscribe(fertilizers => {
      if (fertilizers) {
        const processedFertilizers = {
          ...fertilizers,
          plots: fertilizers.plots.map(plot => {
            const recommendationsMap = new Map<string, ProductRecomendations>();
            if (plot.productRecomendations) {
              plot.productRecomendations.forEach(rec => {
                const existingRec = recommendationsMap.get(rec.name);
                if (existingRec) {
                  existingRec.recomendation += ` ou ${rec.recomendation.toLowerCase()}`;
                } else {
                  recommendationsMap.set(rec.name, { ...rec });
                }
              });
            }
            return {
              ...plot,
              productRecomendations: Array.from(recommendationsMap.values())
            };
          })
        };
        this.fertilizerRecommendations = processedFertilizers;
        this.mapDataForCharts();
      }
    });
  }

  onRowUpdate(updatedRow: Row) {
    const index = this.data.findIndex(row => row['plotName'] === updatedRow['plotName']);
    if (index !== -1) {
      this.data[index] = updatedRow;
    }
  }

  getColor(phrase: string | undefined) {
    if (!phrase) return;
    const lowerPhrase = phrase.toLowerCase();
    if (lowerPhrase.includes('aceitável') || lowerPhrase.includes('médio')) {
      return 'text-blue-600';
    } else if (lowerPhrase.includes('baixo') || lowerPhrase.includes('pouco')) {
      return 'text-red-600';
    } else if (lowerPhrase.includes('adequado') || lowerPhrase.includes('adequada') || lowerPhrase.includes('bom')) {
      return 'text-green-600';
    } else {
      return 'text-orange-600';
    }
  }
}