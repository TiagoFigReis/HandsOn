import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagModule } from 'primeng/tag';
import { LEAF_NUTRIENT_MAP, LeafRecommendation } from '@farm/core';

@Component({
  selector: 'lib-leaf-recommendation-display',
  standalone: true,
  imports: [CommonModule, TagModule],
  templateUrl: './leaf-recommendation-display.component.html',
})
export class LeafRecommendationDisplayComponent {

  @Input() leafRecommendation: LeafRecommendation | undefined;

  getDiagnosisSeverity(level: string): "warn" | "info" | "success" | "danger" {
    const lowerLevel = level.toLowerCase();
    if (lowerLevel.includes('baixo')) {
      return 'warn';
    }
    if (lowerLevel.includes('adequado')) {
        return 'success';
    }
    if (lowerLevel.includes('alto')) {
        return 'danger';
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

