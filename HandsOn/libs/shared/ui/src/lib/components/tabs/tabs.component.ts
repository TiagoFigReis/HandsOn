import { Component, EventEmitter, Input, Output, TemplateRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TabsModule } from 'primeng/tabs';

@Component({
  selector: 'lib-tabs',
  imports: [CommonModule, TabsModule],
  templateUrl: './tabs.component.html',
  styleUrl: './tabs.component.css',
})
export class TabsComponent {
  @Input() tabs: TabItem[] = [];
  @Input() scrollable: true | false = true

  @Output() tabChange = new EventEmitter<string | number>();

  activeIndex: number = 0;

  onTabChange(index: string | number) {
    this.activeIndex = index as number;
    this.tabChange.emit(index);
  }
}

export interface TabItem {
  header: string;
  template: TemplateRef<any>;
}
