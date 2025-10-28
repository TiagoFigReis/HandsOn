import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Row } from '@farm/ui';
import { FertilizerTablesListComponentFacade } from './fertilizer-tables-list.component.facade';

@Component({
  selector: 'lib-fertilizer-tables-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './fertilizer-tables-list.component.html',
  styleUrl: './fertilizer-tables-list.component.css',
})
export class FertilizerTablesListComponent implements OnInit {
  data: Row[] = [];
  loading = false;
  isAdmin = false;

  constructor(private facade: FertilizerTablesListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.fertilizerTables$.subscribe((fertilizerTables) => {
      this.data = fertilizerTables;
    });

    this.facade.isAdmin$.subscribe((isAdmin) => {
      this.isAdmin = isAdmin;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}