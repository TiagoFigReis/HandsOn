import { Component, Input, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Fieldset, FieldsetModule } from 'primeng/fieldset';

@Component({
  selector: 'lib-fieldset',
  imports: [CommonModule, FieldsetModule],
  templateUrl: './fieldset.component.html',
  styleUrl: './fieldset.component.css',
})
export class FieldsetComponent {
  @Input() legend = "Header"
  @Input() toggleable: true | false = false;
  @Input() styleClass = "";
}