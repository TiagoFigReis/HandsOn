import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  AnaliseFacade,
  ConfirmationService,
  Analise,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AnaliseComponentFacade {
    private analiseSubject = new BehaviorSubject<Analise | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private submitLoadingSubject = new BehaviorSubject<boolean>(false);
    private fileSubject = new BehaviorSubject<Blob | null>(null)
  
    id: string | undefined;
    analise$: Observable<Analise | null> = this.analiseSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
    submitLoading$: Observable<boolean> = this.submitLoadingSubject.asObservable();
    file$: Observable<Blob | null> = this.fileSubject.asObservable()
  
    constructor(
      private analiseFacade: AnaliseFacade,
      private confirmationService: ConfirmationService,
      private router: Router,
    ) {}

    load(id: string | undefined) {
        if(!id){
          this.id = id;
          return
        }

        this.id = id;

        this.analiseSubject.next(null);
    
        this.loadingSubject.next(true);
    
        this.analiseFacade
        .getById(id)
          .pipe(
            tap(
              (analise) => {
                this.analiseSubject.next(analise);
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
        this.analiseSubject.next(null);
    }

    submit(analise: Analise) {
        this.confirmationService.confirm({
          message: `Deseja ${this.id ? 'atualizar' : 'criar'} a análise?`,
          accept: () => (this.id ? this.update(analise) : this.add(analise)),
        });
      }

    add(analise: Analise) {
      this.submitLoadingSubject.next(true)  
        this.analiseFacade.create(analise).subscribe({
          next: (analise) => {
            this.submitLoadingSubject.next(false);
            this.router.navigate([`/app/analises/results/${analise.id}`]);  
          },
          error: () => {
            this.submitLoadingSubject.next(false);
          }
        });
      }
    
    update(analise: Analise) {
      this.submitLoadingSubject.next(true);
      this.analiseFacade.update(analise).subscribe({
        next: (analise) => {
          this.submitLoadingSubject.next(false);
          this.router.navigate([`/app/analises/results/${analise.id}`]);  
        },
        error: () => {
          this.submitLoadingSubject.next(false);
        }
      });
    }
}