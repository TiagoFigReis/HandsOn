import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionModule } from 'primeng/accordion';
import { TagModule } from 'primeng/tag';
import { LEAF_NUTRIENT_MAP, LeafRecommendation } from '@farm/core'; // Ajuste o caminho conforme necessário

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

  getLeafNutrientDisplayName(symbol: string): string {
    const nutrientInfo = Object.values(LEAF_NUTRIENT_MAP).find(info => info.symbol === symbol);

    if (nutrientInfo) {
      return `${nutrientInfo.name} (${nutrientInfo.symbol})`;
    }

    return symbol;
  }
}