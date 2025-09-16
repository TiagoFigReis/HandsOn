import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';

interface BaseNutrientAnalysis {
  name: string;
  value: number;
  unit: string;
  inverted?: boolean;
  veryLowMin: number;
  veryHighMax: number;
  scaleMax: number;
}
interface SimpleNutrientAnalysis extends BaseNutrientAnalysis {
  isSimpleRange: true;
  ranges: {
    low: { min: number; max: number };
    medium: { min: number; max: number };
    adequate: { min: number; max: number };
    high: { min: number; max: number };
  };
}
interface ComplexNutrientAnalysis extends BaseNutrientAnalysis {
  isSimpleRange: false;
  ranges: {
    veryLow: { min: number; max: number };
    low: { min: number; max: number };
    medium: { min: number; max: number };
    good: { min: number; max: number };
    veryGood: { min: number; max: number };
  };
}
export type NutrientAnalysis = SimpleNutrientAnalysis | ComplexNutrientAnalysis;

type SimpleClassification = 'low' | 'medium' | 'adequate' | 'high';
type ComplexClassification = 'very-low' | 'low' | 'medium' | 'good' | 'very-good';
type NutrientClassification = SimpleClassification | ComplexClassification;

@Component({
  selector: 'lib-bar-chart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './barChart.component.html',
  styleUrl: './barChart.component.css',
})
export class BarChartComponent {
  @Input() analysisData: NutrientAnalysis[] = [];
  public activeFilter = 'all';

  private simpleColors: Record<SimpleClassification, string> = { 'low': '#e74c3c', 'medium': '#3498db', 'adequate': '#2ecc71', 'high': '#f39c12' };
  private complexColors: Record<ComplexClassification, string> = { 'very-low': '#a93226', 'low': '#e74c3c', 'medium': '#3498db', 'good': '#2ecc71', 'very-good': '#27ae60' };
  private invertedColors: Record<ComplexClassification, string> = { 'very-low': '#27ae60', 'low': '#2ecc71', 'medium': '#3498db', 'good': '#f39c12', 'very-good': '#d35400' };
  
  constructor(private sanitizer: DomSanitizer) {}

  get filteredData(): NutrientAnalysis[] {
    if (this.activeFilter === 'all') {
      return this.analysisData;
    }
    return this.analysisData.filter(item => {
      const displayLevel = this.getDisplayLevel(item);

      switch (this.activeFilter) {
        case 'Adequado':
          return displayLevel === 'Adequado' || displayLevel === 'Bom';
        
        case 'Aceitável':
          return displayLevel === 'Aceitável' || displayLevel === 'Médio';

        default:
          return displayLevel === this.activeFilter;
      }
    });
  }

  setFilter(filter: string): void {
    this.activeFilter = this.activeFilter === filter ? 'all' : filter;
  }

  public getNutrientLevel(item: NutrientAnalysis): NutrientClassification {
    const { value } = item;
    if (item.isSimpleRange) {
      if (value <= item.ranges.low.max) return 'low';
      if (value <= item.ranges.medium.max) return 'medium';
      if (value <= item.ranges.adequate.max) return 'adequate';
      return 'high';
    } else {
      if (value <= item.ranges.veryLow.max) return 'very-low';
      if (value <= item.ranges.low.max) return 'low';
      if (value <= item.ranges.medium.max) return 'medium';
      if (value <= item.ranges.good.max) return 'good';
      return 'very-good';
    }
  }

  public getDisplayLevel(item: NutrientAnalysis): string {
    const level = this.getNutrientLevel(item);
    if (item.isSimpleRange) {
      const labels: Record<SimpleClassification, string> = { 'low': 'Baixo', 'medium': 'Aceitável', 'adequate': 'Adequado', 'high': 'Alto' };
      return labels[level as SimpleClassification];
    } else {
      if (item.inverted) {
        const labels: Record<ComplexClassification, string> = { 'very-low': 'Muito Bom', 'low': 'Bom', 'medium': 'Médio', 'good': 'Alto', 'very-good': 'Muito Alto' };
        return labels[level as ComplexClassification];
      }
      const labels: Record<ComplexClassification, string> = { 'very-low': 'Muito Baixo', 'low': 'Baixo', 'medium': 'Médio', 'good': 'Bom', 'very-good': 'Muito Bom' };
      return labels[level as ComplexClassification];
    }
  }

  public getCurrentColors(item: NutrientAnalysis): Record<string, string> {
    if (item.isSimpleRange) { return this.simpleColors; }
    return item.inverted ? this.invertedColors : this.complexColors;
  }
  
  public getValuePercentage(value: number, item: NutrientAnalysis): number {
    const { veryLowMin, veryHighMax } = item;
    if (veryHighMax === veryLowMin) return 0;
    const totalRange = veryHighMax - veryLowMin;
    const valueRelativeToMin = value - veryLowMin;
    const percentage = (valueRelativeToMin / totalRange) * 100;
    return Math.max(0, Math.min(100, percentage));
  }

  getRangeGradient(item: NutrientAnalysis): SafeStyle {
    const getPercent = (value: number) => this.getValuePercentage(value, item);
    const colors = this.getCurrentColors(item);
    let gradient: string;

    if (item.isSimpleRange) {
      const p1 = getPercent(item.ranges.low.min);
      const p2 = getPercent(item.ranges.low.max);
      const p3 = getPercent(item.ranges.medium.max);
      const p4 = getPercent(item.ranges.adequate.max);
      const p5 = getPercent(item.ranges.high.max);
      gradient = `linear-gradient(to right, 
        ${colors['low']} ${p1}% ${p2}%, 
        ${colors['medium']} ${p2}% ${p3}%,
        ${colors['adequate']} ${p3}% ${p4}%, 
        ${colors['high']} ${p4}% ${p5}%
      )`;
    } else {
      const p1 = getPercent(item.ranges.veryLow.max);
      const p2 = getPercent(item.ranges.low.max);
      const p3 = getPercent(item.ranges.medium.max);
      const p4 = getPercent(item.ranges.good.max);
      const p5 = getPercent(item.ranges.veryGood.max);
      gradient = `linear-gradient(to right, 
        ${colors['very-low']} ${p1}%, 
        ${colors['low']} ${p1}% ${p2}%, 
        ${colors['medium']} ${p2}% ${p3}%, 
        ${colors['good']} ${p3}% ${p4}%, 
        ${colors['very-good']} ${p4}% ${p5}%
      )`;
    }
    
    return this.sanitizer.bypassSecurityTrustStyle(gradient);
  }
}