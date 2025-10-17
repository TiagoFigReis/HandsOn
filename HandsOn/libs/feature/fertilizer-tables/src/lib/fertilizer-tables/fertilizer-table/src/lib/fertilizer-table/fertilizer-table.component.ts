import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { FertilizerTable, User } from '@farm/core';
import { CardComponent, FertilizerTableFormComponent } from '@farm/ui';
import { FertilizerTableComponentFacade } from './fertilizer-table.component.facade';

@Component({
  selector: 'lib-fertilizer-table',
  imports: [CommonModule, CardComponent, FertilizerTableFormComponent, RouterModule],
  templateUrl: './fertilizer-table.component.html',
  styleUrl: './fertilizer-table.component.css',
})
export class FertilizerTableComponent implements OnInit, OnDestroy {
  id: string | undefined;
  fertilizerTable: FertilizerTable | undefined;
  user: User | undefined;
  loading = false;
  selectCulture = false;

  title = 'Criar Tabela de Fertilizantes';
  description = 'Preencha os campos abaixo para criar a tabela';
  submitLabel = 'Cadastrar';

  constructor(
    private route: ActivatedRoute,
    private facade: FertilizerTableComponentFacade,
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      this.selectCulture = true;

      return;
    }

    this.title = 'Editar Tabela de Fertilizantes';
    this.description = 'Preencha os campos abaixo para editar a tabela';
    this.submitLabel = 'Editar';

    this.facade.load(this.id);

    this.facade.fertilizerTable$.subscribe((fertilizerTable) => {
      if (!fertilizerTable) return;

      this.fertilizerTable = fertilizerTable;
    });

    this.facade.user$.subscribe((user) => {
      if (!user) return;

      this.user = user;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(fertilizerTable: FertilizerTable) {
    this.facade.submit(fertilizerTable);
  }
}