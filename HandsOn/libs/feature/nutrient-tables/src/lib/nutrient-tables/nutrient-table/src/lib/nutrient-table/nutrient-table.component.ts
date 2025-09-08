import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { NutrientTable, User } from '@farm/core';
import { CardComponent, NutrientTableFormComponent } from '@farm/ui';
import { NutrientTableComponentFacade } from './nutrient-table.component.facade';

@Component({
  selector: 'lib-nutrient-table',
  imports: [CommonModule, CardComponent, NutrientTableFormComponent, RouterModule],
  templateUrl: './nutrient-table.component.html',
  styleUrl: './nutrient-table.component.css',
})
export class NutrientTableComponent implements OnInit, OnDestroy{
  id: string | undefined;
  nutrientTable: NutrientTable | undefined;
  user: User | undefined;
  loading = false;
  selectCulture = false;

  title = 'Criar Tabela de Nutrientes';
  description = '';
  submitLabel = 'Cadastrar';

  constructor(
    private route: ActivatedRoute,
    private facade: NutrientTableComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      this.selectCulture = true;
      
      return;
    }

    this.title = 'Editar Tabela de Nutrientes';
    this.description = 'Preencha os campos abaixo para editar a tabela';
    this.submitLabel = 'Editar';

    this.facade.load(this.id);

    this.facade.nutrientTable$.subscribe((nutrientTable) => {
      if (!nutrientTable) return;

      this.nutrientTable = nutrientTable;
    });

    this.facade.user$.subscribe((user) => {
      if(!user) return;

      this.user = user;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(nutrientTable: NutrientTable) {
    this.facade.submit(nutrientTable);
  }
}