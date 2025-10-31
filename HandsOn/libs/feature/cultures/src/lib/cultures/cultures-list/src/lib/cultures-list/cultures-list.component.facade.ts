import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import {
  Culture,
  CultureFacade,
  ConfirmationService
} from '@farm/core';
import { Action } from '@farm/ui';
import { Router } from '@angular/router';

export type CultureWithActions = Culture & { actions: Action[] };

@Injectable({
  providedIn: 'root',
})
export class CulturesListComponentFacade {
  private culturesSubject = new BehaviorSubject<CultureWithActions[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private submittingSubject = new BehaviorSubject<boolean>(false);

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  submitting$: Observable<boolean> = this.submittingSubject.asObservable();
  cultures$: Observable<CultureWithActions[]> = this.culturesSubject.asObservable();

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
        map((cultures) =>
          cultures.map((culture) => this.mapCultureWithActions(culture)),
        ),
        tap(
          (cultures) => {
            this.culturesSubject.next(cultures);
            this.loadingSubject.next(false);
          },
          () => {
            this.loadingSubject.next(false);
          },
        ),
      )
      .subscribe();
  }

  private mapCultureWithActions(culture: Culture): CultureWithActions {
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
      message: `Deseja criar a cultura "${culture.name}"?`,
      accept: () => this.createCulture(culture)
    });
  }

  private createCulture(culture: Culture) {
    this.submittingSubject.next(true);
    const create$ = this.cultureFacade.createCulture(culture as Culture);

    create$.subscribe({
      next: () => {
        this.load();
        this.submittingSubject.next(false);
      },
      error: () => {
        this.submittingSubject.next(false);
      }
    });
  }
}