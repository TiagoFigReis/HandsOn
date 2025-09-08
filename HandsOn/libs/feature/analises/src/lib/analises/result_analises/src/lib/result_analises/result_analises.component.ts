import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Analise, DadosAnalise, Nutrients, RecommendFertilizers, ProductRecomendations, Spacing } from '@farm/core';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { TableModule } from 'primeng/table';
import { CardModule } from 'primeng/card';
import { ResultAnaliseComponentFacade } from './result_analises.component.facade';
import { Column, Row, TableComponent, ButtonComponent, SpinnerComponent } from '@farm/ui';
import { filter, switchMap, take } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { AccordionModule } from 'primeng/accordion';

@Component({
  selector: 'lib-result-analises',
  imports: [CommonModule, TableModule, CardModule, ButtonComponent, InputNumberModule, InputTextModule, FormsModule, SpinnerComponent, RouterModule, TableComponent, AccordionModule],
  templateUrl: './result_analises.component.html',
  styleUrl: './result_analises.component.css',
})
export class ResultAnalisesComponent implements OnInit {
  id: string | undefined = undefined;
  loading = true;
  formData = new FormData();
  tipoAnalise = 0;
  resultsData: DadosAnalise | null = null
  showMoreButton = false;
  analise: Analise | undefined;
  data: Row[] = [];
  columns: Column[] = [];
  editable = true
  tipo = 0;
  fertilizerRecommendations: RecommendFertilizers | undefined;

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

    this.dataAnalyseFacade.loadAnalyse(this.id);

    this.dataAnalyseFacade.analise$.subscribe((analiseData) => {
      if (analiseData) {
        this.data = analiseData;
      }
    });

    this.dataAnalyseFacade.tipo$.subscribe((tipo) => {
      this.tipo = tipo;
    })
    
    this.dataAnalyseFacade.columns$.subscribe((cols) => {
      if(cols){
        this.columns = cols;
      }
    });

    this.dataAnalyseFacade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  refresh() {
    this.dataAnalyseFacade.loadAnalyse(this.id);
  }

  solicitar_recomendacoes() {
    const headerMap = this.getHeaderMap();

    const plotsForAnalysis = this.data.map((item) => {
      const nutrients = Object.keys(headerMap).map((nutrientName) => {
        const value = Number(item[nutrientName]) || 0; 
        
        const nutrient: Nutrients = {
          header: Number(headerMap[nutrientName]),
          value: value
        };
        return nutrient;
      });

      return {
        plotName: item['plotName']?.toString() || '',
        cultureType: item['cultureType']?.toString() || '', 
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
      filter(dataAnalyse => !!dataAnalyse && !!dataAnalyse.plots), 
      take(1), 
      switchMap(dataAnalyse => {
        if(!dataAnalyse) return EMPTY

        const headerMap = this.getReverseHeaderMap();

        const plotsForAnalysis = dataAnalyse.plots.map((item) => {
        const nutrients : Nutrients[] = item.nutrients?.map(n => {
          const mappedHeader = headerMap[n.header];
          return {
            ...n,
            header: mappedHeader ?? n.header
          };
        }) || [];

        return {
          plotName: item['plotName']?.toString() || '',
          cultureType: item['cultureType']?.toString() || '', 
          nutrients
        };
      });

        const productivityMap = new Map<string, number>();
        this.data.forEach(row => {
            productivityMap.set(
                row['plotName']?.toString() || '', 
                Number(row['expectedProductivity']) || 0
            );
        });

        const spacingMap = new Map<string, Spacing>();
        this.data.forEach(row => {
            spacingMap.set(
                row['plotName']?.toString() || '', 
                {width: Number(row['width']), height: Number(row['height']) }
            );
        });

        dataAnalyse.plots = dataAnalyse.plots.map(plot => ({
            ...plot,
            expectedProductivity: productivityMap.get(plot.plotName || '') || 0,
            spacing: spacingMap.get(plot.plotName || '')
        }));

        this.resultsData = dataAnalyse

        const fertilizersPayload: RecommendFertilizers = {
          soilRecomendation: !this.tipo,
          plots: dataAnalyse.plots
        };
        
        this.dataAnalyseFacade.recommendFertilizers(fertilizersPayload);

        this.resultsData.plots = plotsForAnalysis
        
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

        this.fertilizerRecommendations = processedFertilizers
        
      }
    });
  }

  getHeaderMap(): { [key: string]: string } {
    if (this.tipo) {
      return {
        'N (g/kg)': '0', 'P (g/kg)': '1', 'K (g/kg)': '2', 'Ca (g/kg)': '3',
        'Mg (g/kg)': '4', 'S (g/kg)': '5', 'Zn (ppm)': '6', 'B (ppm)': '7',
        'Cu (ppm)': '8', 'Mn (ppm)': '9', 'Fe (ppm)': '10',
      };
    } else {
      return {
        'P (ppm)': '1', 'K (cmolc/dm³)': '2', 'Ca (cmolc/dm³)': '3', 'Mg (cmolc/dm³)': '4',
        'S (ppm)': '5', 'Zn (ppm)': '6', 'B (ppm)': '7', 'Cu (ppm)': '8',
        'Mn (ppm)': '9', 'Fe (ppm)': '10', 'pH H2O' : '24', 'Al (cmolc/dm³)' : '25',
        'H+Al (cmolc/dm³)': '26', 'M.O (%)': '27', 'SB (cmolc/dm³)' : '28',
        'T (cmolc/dm³)' : '29', 'v (%)': '30',
      };
    }
  }

  getReverseHeaderMap() : {[key:string]:string} {
    if (this.tipo){
      return{
      'N' : 'N (g/kg)',
      'P': 'P (g/kg)',
      'K': 'K (g/kg)',
      'Ca': 'Ca (g/kg)',
      'Mg': 'Mg (g/kg)',
      'S': 'S (g/kg)',
      'Zn': 'Zn (ppm)',
      'B': 'B (ppm)',
      'Cu': 'Cu (ppm)',
      'Mn': 'Mn (ppm)',
      'Fe': 'Fe (ppm)',
      'NP' : 'N/P',
      'NK' : 'N/K',
      'NS' : 'N/S',
      'NB' : 'N/B',
      'NCu' : 'N/Cu',
      'PMg' : 'P/Mg',
      'PZn' : 'P/Zn',
      'KCa' : 'K/Ca',
      'KMg' : 'K/Mg',
      'KMn' : 'K/Mn',
      'CaMg': 'Ca/Mg',
      'CaMn' :'Ca/Mn',
      'FeMn' : 'Fe/Mn'
      }
    }else{
      return{
      'N' : 'N (ppm)',
      'P': 'P (ppm)',
      'K': 'K (cmolc/dm³)',
      'Ca': 'Ca (cmolc/dm³)',
      'Mg': 'Mg (cmolc/dm³)',
      'S': 'S (ppm)',
      'Zn': 'Zn (ppm)',
      'B': 'B (ppm)',
      'Cu': 'Cu (ppm)',
      'Mn': 'Mn (ppm)',
      'Fe': 'Fe (ppm)',
      'Saturação por Al' : 'Al (cmolc/dm³)',
      'Acidez Potencial' : 'H+Al (cmolc/dm³)',
      'Matéria Orgânica' : 'M.O (%)',
      'Soma de bases' : 'SB (cmolc/dm³)',
      'CTC pH 7.0' : 'T (cmolc/dm³)',
      'Saturação por Bases' : 'v (%)'
      }
    }
  }

  onRowUpdate(updatedRow: Row){
    const index = this.data.findIndex(row => row['plotName'] === updatedRow['plotName']);
    
    if (index !== -1) {
      this.data[index] = updatedRow;
    }
  }

  getColor(phrase: string | undefined){
    if(!phrase) return 

    const lowerPhrase = phrase.toLowerCase()

    if(lowerPhrase.includes('aceitável')){
      return 'text-blue-600'
    }else if( lowerPhrase.includes('baixo') || lowerPhrase.includes('pouco')){
      return 'text-red-600'
    }else if(lowerPhrase.includes('adequado') || lowerPhrase.includes('adequada')){
      return 'text-green-600'
    }else{
      return 'text-orange-600'
    }
  }
}