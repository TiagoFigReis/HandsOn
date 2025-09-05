import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Culture,
  CultureFacade,
  ConfirmationService
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class CultureComponentFacade {
  private cultureSubject = new BehaviorSubject<Culture | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  id: string | undefined;

  culture$: Observable<Culture | null> = this.cultureSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  constructor(
    private cultureFacade: CultureFacade,
    private confirmationService: ConfirmationService,
    private router: Router,
  ) { }

  load(id: string) {
    this.id = id;

    this.loadingSubject.next(true);

    this.cultureFacade
      .getCultureById(id)
      .pipe(
        tap(
          (culture) => {
            this.cultureSubject.next(culture);
            this.loadingSubject.next(false);
          },
          (error) => {
            const code = error.code;
            if (code === 400 || code === 404) this.router.navigate(['/404']);
          },
        ),
      )
      .subscribe();
  }

  reset() {
    this.cultureSubject.next(null);
  }

  submit(culture: Culture) {
    this.confirmationService.confirm({
      message: `Deseja atualizar a cultura?`,
      accept: () => this.updateCulture(culture)
    });
  }

  private updateCulture(culture: Culture) {
    this.cultureFacade.updateCulture(culture).subscribe(() => {
      this.router.navigate(['/app/cultures']);
    });
  }
}
