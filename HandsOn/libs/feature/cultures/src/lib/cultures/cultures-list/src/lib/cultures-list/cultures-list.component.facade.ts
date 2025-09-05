import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Culture,
  CultureFacade,
  ConfirmationService
} from '@farm/core';
import { Row, Action } from '@farm/ui';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class CulturesListComponentFacade {
  private culturesSubject = new BehaviorSubject<Row[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  cultures$: Observable<Row[]> = this.culturesSubject.asObservable();

  constructor(
    private cultureFacade: CultureFacade,
    private confirmationService: ConfirmationService,
    private router: Router
  ) { }

  load() {
    this.loadingSubject.next(true);

    this.cultureFacade
      .getAllCultures()
      .pipe(
        tap(
          (categories) => {
            this.culturesSubject.next(
              categories.map((culture) => this.mapCultureToRow(culture)),
            );
            this.loadingSubject.next(false);
          },
          () => {
            this.loadingSubject.next(false);
          },
        ),
      )
      .subscribe();
  }

  private mapCultureToRow(culture: Culture): Row {
    const { ...data } = culture;

    return {
      ...data,

      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/cultures/${culture.id}`,
        },
        {
          tooltip: 'Excluir',
          icon: 'pi pi-fw pi-trash',
          iconClass: 'error',
          command: (event, data) => {
            this.confirmationService.confirm({
              header: 'Excluir Cultura',
              message: `Deseja excluir a cultura "${data.name}"?`,
              accept: () => {
                this.cultureFacade.deleteCulture(data.id).subscribe(() => {
                  this.load();
                });
              },
            });
          },
        },
      ] as Action[],
    };
  }

  submit(culture: Culture) {
    this.confirmationService.confirm({
      message: `Deseja criar a cultura?`,
      accept: () => this.createCulture(culture)
    });
  }

  private createCulture(culture: Culture) {
    const create$ = this.cultureFacade.createCulture(culture as Culture);

    create$.subscribe(() => {
      this.load();
    });
  }
}
