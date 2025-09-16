import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionModule } from 'primeng/accordion';
import { TagModule } from 'primeng/tag';
import { LeafRecommendation } from '@farm/core'; // Ajuste o caminho conforme necessário

@Component({
  selector: 'lib-leaf-recommendation-display',
  standalone: true,
  imports: [CommonModule, AccordionModule, TagModule],
  templateUrl: './leaf-recommendation-display.component.html',
})
export class LeafRecommendationDisplayComponent {

  @Input() leafRecommendation: LeafRecommendation | undefined;

  getDiagnosisSeverity(level: string): "warn" | "info" {
    const lowerLevel = level.toLowerCase();
    if (lowerLevel.includes('baixo')) {
      return 'warn';
    }
    return 'info';
  }
}