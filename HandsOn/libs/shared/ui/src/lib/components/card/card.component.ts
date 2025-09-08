import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-card',
  imports: [CommonModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css',
})
export class CardComponent {
  @Input() class = "w-full max-w-3xl secondary-background py-12 px-6 rounded-md shadow mx-auto relative border primary-border"
}
