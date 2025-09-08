import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DividerModule } from 'primeng/divider';

@Component({
  selector: 'lib-divider',
  imports: [CommonModule, DividerModule],
  templateUrl: './divider.component.html',
  styleUrl: './divider.component.css',
})
export class DividerComponent {
  @Input() layout: "horizontal" | "vertical" = "horizontal";
  @Input() type: "solid" | "dotted" | "dashed" = "solid";
  @Input() align: "left" | "center" | "right" = "center";
}
