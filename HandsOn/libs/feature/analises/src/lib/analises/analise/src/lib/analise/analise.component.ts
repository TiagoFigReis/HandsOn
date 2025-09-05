import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Analise } from '@farm/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CardComponent, AnaliseFormComponent } from "@farm/ui"
import { AnaliseComponentFacade } from "./analise.component.facade";
import { SpinnerComponent } from '@farm/ui';

@Component({
  selector: 'lib-analise',
  imports: [CommonModule,RouterModule, CardComponent, AnaliseFormComponent, SpinnerComponent],
  templateUrl: './analise.component.html',
  styleUrl: './analise.component.css',
})
export class AnaliseComponent implements OnInit, OnDestroy {
  id: string | undefined;
  analise: Analise | undefined;
  loading = false;
  submitLoading = false;

  title = 'Adicionar Análise';
  description = 'Preencha os campos abaixo para adicionar uma análise';
  submitLabel = 'Adicionar';

  constructor(
    private route: ActivatedRoute,
    private facade: AnaliseComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    this.facade.load(this.id);

    this.facade.submitLoading$.subscribe((loading) => {
      this.submitLoading = loading;
    })

    if (!this.id) {
      return;
    }

    this.title = 'Editar Análise';
    this.description = 'Preencha os campos abaixo para editar a análise';
    this.submitLabel = 'Editar';

    this.facade.analise$.subscribe((analise) => {
      if (!analise) return;

      this.analise = analise;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(analise: Analise) {
    this.facade.submit(analise);
  }
}
