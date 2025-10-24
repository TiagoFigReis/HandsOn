import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';

type SimpleClassification = 'low' | 'medium' | 'adequate' | 'high';
type ComplexClassification = 'very-low' | 'low' | 'medium' | 'good' | 'very-good';
type NutrientClassification = SimpleClassification | ComplexClassification;
export type NutrientAnalysis = any;

@Component({
  selector: 'lib-bar-chart',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './barChart.component.html',
})
export class BarChartComponent {
  @Input({ required: true }) analysisData!: NutrientAnalysis;
  @Output() valueChanged = new EventEmitter<NutrientAnalysis>();

  constructor(private sanitizer: DomSanitizer) {}

  onValueChange(newValue: number): void {
    const updatedAnalysis = { ...this.analysisData, value: newValue };
    this.valueChanged.emit(updatedAnalysis);
  }

  public getNutrientLevel(): NutrientClassification {
    const { value } = this.analysisData;
    if (this.analysisData.isSimpleRange) {
      if (value <= this.analysisData.ranges.low.max) return 'low';
      if (value <= this.analysisData.ranges.medium.max) return 'medium';
      if (value <= this.analysisData.ranges.adequate.max) return 'adequate';
      return 'high';
    } else {
      if (value <= this.analysisData.ranges.veryLow.max) return 'very-low';
      if (value <= this.analysisData.ranges.low.max) return 'low';
      if (value <= this.analysisData.ranges.medium.max) return 'medium';
      if (value <= this.analysisData.ranges.good.max) return 'good';
      return 'very-good';
    }
  }

  public getDisplayLevel(): string {
    const level = this.getNutrientLevel();
    if (this.analysisData.isSimpleRange) {
      const labels: Record<SimpleClassification, string> = { 'low': 'Baixo', 'medium': 'Aceitável', 'adequate': 'Adequado', 'high': 'Alto' };
      return labels[level as SimpleClassification];
    } else {
      if (this.analysisData.inverted) {
        const labels: Record<ComplexClassification, string> = { 'very-low': 'Muito Bom', 'low': 'Bom', 'medium': 'Médio', 'good': 'Alto', 'very-good': 'Muito Alto' };
        return labels[level as ComplexClassification];
      }
      const labels: Record<ComplexClassification, string> = { 'very-low': 'Muito Baixo', 'low': 'Baixo', 'medium': 'Médio', 'good': 'Bom', 'very-good': 'Muito Bom' };
      return labels[level as ComplexClassification];
    }
  }
  
  public getNutrientLevelClass(): any {
    const level = this.getDisplayLevel();
    const color = {
      'bg-red-600': level === 'Muito Baixo' || (this.analysisData.inverted && level === 'Muito Alto'),
      'bg-red-500': level === 'Baixo' || (this.analysisData.inverted && level === 'Alto' ),
      'bg-yellow-500': level === 'Alto' && !this.analysisData.inverted,
      'bg-blue-500': level === 'Médio' || level === 'Aceitável',
      'bg-green-500': level === 'Bom'|| level === 'Adequado',
      'bg-green-600' : level === 'Muito Bom'
    };
    return color;
  }
  
  public getValuePercentage(value: number): number {
    const { veryLowMin, scaleMax } = this.analysisData;
    if (scaleMax === veryLowMin) return 0;
    const percentage = ((value - veryLowMin) / (scaleMax - veryLowMin)) * 100;
    return Math.max(0, Math.min(100, percentage));
  }

  getRangeGradient(): SafeStyle {
    let colors = {
        'very-low': '#a93226', 'low': '#e74c3c', 'medium': '#3498db',
        'good': '#2ecc71', 'very-good': '#27ae60', 'adequate': '#2ecc71', 'high': '#f39c12'
    };

    if (this.analysisData.inverted) {
        colors = {
            'very-low': '#27ae60', 'low': '#2ecc71', 'medium': '#3498db',
            'good': '#e74c3c', 'very-good': '#a93226', 'adequate': '#2ecc71', 'high': '#f39c12'
        };
    }

    let stops = '';
    if (this.analysisData.isSimpleRange) {
        stops = `
            ${colors['low']} 0%, ${colors['low']} ${this.getValuePercentage(this.analysisData.ranges.low.max)}%,
            ${colors['medium']} ${this.getValuePercentage(this.analysisData.ranges.low.max)}%, ${colors['medium']} ${this.getValuePercentage(this.analysisData.ranges.medium.max)}%,
            ${colors['adequate']} ${this.getValuePercentage(this.analysisData.ranges.medium.max)}%, ${colors['adequate']} ${this.getValuePercentage(this.analysisData.ranges.adequate.max)}%,
            ${colors['high']} ${this.getValuePercentage(this.analysisData.ranges.adequate.max)}%, ${colors['high']} 100%
        `;
    } else {
        stops = `
            ${colors['very-low']} 0%, ${colors['very-low']} ${this.getValuePercentage(this.analysisData.ranges.veryLow.max)}%,
            ${colors['low']} ${this.getValuePercentage(this.analysisData.ranges.veryLow.max)}%, ${colors['low']} ${this.getValuePercentage(this.analysisData.ranges.low.max)}%,
            ${colors['medium']} ${this.getValuePercentage(this.analysisData.ranges.low.max)}%, ${colors['medium']} ${this.getValuePercentage(this.analysisData.ranges.medium.max)}%,
            ${colors['good']} ${this.getValuePercentage(this.analysisData.ranges.medium.max)}%, ${colors['good']} ${this.getValuePercentage(this.analysisData.ranges.good.max)}%,
            ${colors['very-good']} ${this.getValuePercentage(this.analysisData.ranges.good.max)}%, ${colors['very-good']} 100%
        `;
    }
    return this.sanitizer.bypassSecurityTrustStyle(`linear-gradient(to right, ${stops})`);
  }
}
