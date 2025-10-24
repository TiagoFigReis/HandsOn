import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { AnalisesListComponentFacade, AnalyseWithActions } from './analises-list.component.facade';

@Component({
  selector: 'lib-analises-list',
  imports: [CommonModule, RouterLink],
  templateUrl: './analises-list.component.html',
  styleUrl: './analises-list.component.css',
})
export class AnalisesListComponent implements OnInit{
  data: AnalyseWithActions[] = [];
  loading = false;

  constructor(
    private facade: AnalisesListComponentFacade
  ) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.analises$.subscribe((analises) => {
      this.data = analises
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }

  async downloadFile(blob: Blob, filename: string) {
    const blobUrl = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = blobUrl;
    a.download = filename;
    a.click();
    window.URL.revokeObjectURL(blobUrl);
  }
}