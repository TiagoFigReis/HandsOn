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

@Component({
  selector: 'lib-bar-chart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './barChart.component.html',
  styleUrl: './barChart.component.css',
})
export class BarChartComponent {
  
  @Input() analysisData: NutrientAnalysis[] = [];

  constructor(private sanitizer: DomSanitizer) {}

  getValuePercentage(value: number, scaleMax: number): number {
    if (scaleMax === 0) return 0;
    const clampedValue = Math.min(value, scaleMax);
    return (clampedValue / scaleMax) * 100;
  }

  getRangeGradient(item: NutrientAnalysis): SafeStyle {
    const { ranges, scaleMax } = item;
    
    const lowColor = '#e74c3c';      // Vermelho
    const mediumColor = '#3498db';    // Azul
    const adequateColor = '#2ecc71'; // Verde
    const highColor = '#f39c12';      // laranja

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