import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Culture } from '@farm/core';
import { CardComponent, CultureFormComponent } from '@farm/ui';
import { CultureComponentFacade } from './culture.component.facade';

@Component({
  selector: 'lib-culture',
  imports: [CommonModule, CardComponent, CultureFormComponent, RouterModule],
  templateUrl: './culture.component.html',
  styleUrl: './culture.component.css',
})
export class CultureComponent implements OnInit, OnDestroy {
  id: string | undefined;
  culture: Culture | undefined;
  loading = false;

  title = 'Editar Cultura';
  description = 'Preencha os campos abaixo para editar a cultura';
  submitLabel = 'Editar';

  constructor(
    private route: ActivatedRoute,
    private facade: CultureComponentFacade,
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      return;
    }
    
    this.facade.load(this.id);

    this.facade.culture$.subscribe((culture) => {
      if (!culture) return;

      this.culture = culture;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(culture: Culture) {
    this.facade.submit(culture);
  }
}
