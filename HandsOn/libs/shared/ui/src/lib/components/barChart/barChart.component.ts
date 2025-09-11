import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';

export interface NutrientAnalysis {
  name: string;
  value: number;
  unit: string;
  ranges: {
    low: { min: number; max: number };
    medium: { min: number; max: number };
    adequate: { min: number; max: number };
    high: { min: number; max: number };
  };
  scaleMax: number;
}

type NutrientLevel = 'low' | 'medium' | 'adequate' | 'high' | 'all';

@Component({
  selector: 'lib-bar-chart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './barChart.component.html',
  styleUrl: './barChart.component.css',
})
export class BarChartComponent {

  @Input() analysisData: NutrientAnalysis[] = [];
  
  public activeFilter: NutrientLevel = 'all';

  constructor(private sanitizer: DomSanitizer) {}

  get filteredData(): NutrientAnalysis[] {
    if (this.activeFilter === 'all') {
      return this.analysisData;
    }
    return this.analysisData.filter(item => this.getNutrientLevel(item) === this.activeFilter);
  }

  setFilter(filter: NutrientLevel): void {
    this.activeFilter = this.activeFilter === filter ? 'all' : filter;
  }

  private getNutrientLevel(item: NutrientAnalysis): Omit<NutrientLevel, 'all'> {
    const { value, ranges } = item;
    if (value <= ranges.low.max) return 'low';
    if (value <= ranges.medium.max) return 'medium';
    if (value <= ranges.adequate.max) return 'adequate';
    return 'high';
  }

  getValuePercentage(value: number, scaleMax: number): number {
    if (scaleMax === 0) return 0;
    const clampedValue = Math.min(value, scaleMax);
    return (clampedValue / scaleMax) * 100;
  }

  getRangeGradient(item: NutrientAnalysis): SafeStyle {
    const { ranges, scaleMax } = item;
    
    const lowColor = '#e74c3c';
    const mediumColor = '#3498db';
    const adequateColor = '#2ecc71';
    const highColor = '#f39c12';

    const lowEnd = (ranges.low.max / scaleMax) * 100;
    const mediumStart = lowEnd;
    const mediumEnd = (ranges.medium.max / scaleMax) * 100;
    const adequateStart = mediumEnd;
    const adequateEnd = (ranges.adequate.max / scaleMax) * 100;
    const highStart = adequateEnd;

    const gradient = `linear-gradient(to right, 
      ${lowColor} ${mediumStart}%, 
      ${mediumColor} ${mediumStart}% ${mediumEnd}%, 
      ${adequateColor} ${adequateStart}% ${adequateEnd}%, 
      ${highColor} ${highStart}% 100%
    )`;

    return this.sanitizer.bypassSecurityTrustStyle(gradient);
  }
}