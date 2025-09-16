import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Analise, DadosAnalise, Nutrients, RecommendFertilizers, NutrientTable, Plots } from '@farm/core';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { TableModule } from 'primeng/table';
import { CardModule } from 'primeng/card';
import { ResultAnaliseComponentFacade } from './result_analises.component.facade';
import { Column, Row, TableComponent, ButtonComponent, SpinnerComponent, NutrientAnalysis } from '@farm/ui';
import { filter, map, switchMap } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { AccordionModule } from 'primeng/accordion';
import { BarChartComponent } from '@farm/ui';
import { LEAF_NUTRIENT_MAP, SOIL_NUTRIENT_MAP } from '@farm/core';
import {RecommendationDisplayComponent} from './recommendation-display/recommendation-display.component';
import { LeafRecommendationDisplayComponent } from './leaf-recommendation-display/leaf-recommendation-display.component';

@Component({
  selector: 'lib-result-analises',
  imports: [CommonModule, TableModule, CardModule, ButtonComponent, InputNumberModule, InputTextModule, 
    FormsModule, SpinnerComponent, RouterModule, TableComponent, AccordionModule, BarChartComponent,
     RecommendationDisplayComponent, LeafRecommendationDisplayComponent],
  templateUrl: './result_analises.component.html',
  styleUrl: './result_analises.component.css',
})
export class ResultAnalisesComponent implements OnInit {
  id: string | undefined = undefined;
  loading = true;
  formData = new FormData();
  tipoAnalise = 0;
  resultsData: DadosAnalise | null = null;
  showMoreButton = true;
  analise: Analise | undefined;
  data: Row[] = [];
  columns: Column[] = [];
  editable = true;
  tipo = 0;
  fertilizerRecommendations: RecommendFertilizers | undefined;
  table: NutrientTable | undefined;
  leafChartData: NutrientAnalysis[] = [];
  soilChartData: NutrientAnalysis[] = [];

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

    this.dataAnalyseFacade.loadAnalyse(this.id)

    this.dataAnalyseFacade.analise$.subscribe((analiseData) => {
      if (analiseData) {
        this.data = analiseData;
      }}
    );
    
    this.dataAnalyseFacade.infosAnalise$.subscribe((analise) => {
      if(analise){
        this.analise = analise
      }
    })

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

   mapDataForCharts(plot : Plots): NutrientAnalysis[] {
    if (!this.table) {
      return [];
    }
    const plotData = plot
    if (this.tipo === 0 && this.table.soilNutrientRow) {
      return this.transformNutrients(plotData.nutrients || [], this.table.soilNutrientRow.nutrientColumns);
    } else if (this.tipo === 1 && this.table.leafNutrientRows?.length) {
      return this.transformNutrients(plotData.nutrients || [], this.table.leafNutrientRows[0].nutrientColumns);
    }
    return []
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

        const clear = (str : string) =>{
          return str.replace(/\s+[A-Za-z%µ/²³]+$/, "")
        }

        chartData.push({
          name: clear(info.displayName),
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

  refresh() {
    this.dataAnalyseFacade.loadAnalyse(this.id);
  }

  plotsForAnalysis(): Plots[] {
    const activeNutrientMap = this.tipo ? LEAF_NUTRIENT_MAP : SOIL_NUTRIENT_MAP;

    return this.data.map((item) => {
      const nutrients = Object.entries(activeNutrientMap).map(([nutrientCode, info]) => {
        const value = Number(item[info.displayName]) || 0;
        return { header: Number(nutrientCode), value: value };
      });
      return {
        plotName: item['plotName']?.toString(),
        cultureType: item['cultureType']?.toString(),
        expectedProductivity: Number(item['expectedProductivity']),
        width: Number(item['width']),
        height: Number(item['height']),
        nutrients
      } as Plots;
    });
  }

  solicitar_recomendacoes() {
    
    const plotsForAnalysis : Plots[] = this.plotsForAnalysis()

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

        this.resultsData = { ...dataAnalyse, plots: dataAnalyse.plots };

        const fertilizersPayload: RecommendFertilizers = {
          soilRecomendation: !this.tipo,
          plots: dataAnalyse.plots
        };

        this.dataAnalyseFacade.recommendFertilizers(fertilizersPayload);
        return this.dataAnalyseFacade.fertilizers$;
      })
    ).subscribe(fertilizers => {
      if (fertilizers) {
        this.fertilizerRecommendations = fertilizers;
      }
    });
  }

  onSave(){
    if (this.analise && this.analise.dadosAnalise) {
        this.analise.dadosAnalise.plots = this.plotsForAnalysis();
        this.dataAnalyseFacade.updateAnalyse(this.analise);
    }
  }

  onRowUpdate(updatedRow: Row) {
    const index = this.data.findIndex(row => row['id'] === updatedRow['id']);
    if (index !== -1) {
      this.data[index] = updatedRow;
    }
  }
}