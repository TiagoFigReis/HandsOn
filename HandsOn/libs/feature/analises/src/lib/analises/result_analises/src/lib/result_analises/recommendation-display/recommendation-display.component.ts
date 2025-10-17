import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionModule } from 'primeng/accordion';
import { TagModule } from 'primeng/tag';
import { DividerModule } from 'primeng/divider';
import { Recommendation } from '@farm/core';

@Component({
  selector: 'lib-recommendation-display',
  imports: [CommonModule, AccordionModule, TagModule, DividerModule],
  templateUrl: './recommendation-display.component.html',
  styleUrl: './recommendation-display.component.css',
})
export class RecommendationDisplayComponent {
  @Input() recommendation: Recommendation | undefined;

  getBalanceSeverity(result: string): "success" | "secondary" | "info" | "warn" | "danger" | "contrast" | undefined {
    const lowerResult = result.toLowerCase();
    if (lowerResult.includes('atendido')) return 'success';
    if (lowerResult.includes('excesso')) return 'warn';
    if (lowerResult.includes('déficit')) return 'danger';
    return 'info';
  }

}
