import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {
  Analise,
  AnaliseFacade,
  ConfirmationService,
} from '@farm/core';
import { Row, Action } from '@farm/ui';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AnalisesListComponentFacade {
  private analisesSubject = new BehaviorSubject<Row[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  analises$: Observable<Row[]> = this.analisesSubject.asObservable();

  constructor(
    private analiseFacade: AnaliseFacade,
    private confirmationService: ConfirmationService,
    private router: Router,
  ) {}

  async load() {
    this.loadingSubject.next(true);

    try {
      const analises = await firstValueFrom(this.analiseFacade.getAll());
      const rows: Row[] = [];

      for (const analise of analises) {
        try {
          const blob = await this.getFile(analise.id);

          if(blob) analise.blob = blob

          rows.push(this.mapAnaliseToRow(analise));
        } catch (err) {
          console.error('Erro ao obter arquivo da análise:', err);
          continue;
        }
      }

      this.analisesSubject.next(rows);
    } catch (err) {
      console.error('Erro ao carregar análises:', err);
    } finally {
      this.loadingSubject.next(false);
    }
  }

  async getFile(id: string | undefined): Promise<Blob | undefined> {
    if (!id) return;

    try {
      const file = await firstValueFrom(this.analiseFacade.getFile(id));
      return file;
    } catch (error: any) {
      const code = error?.code;
      if (code === 400 || code === 404) {
        this.router.navigate(['/404']);
      }
      throw error;
    }
  }

  private mapAnaliseToRow(analise: Analise): Row {
    return {
      ...analise,
      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/analises/${analise.id}`,
        },
        {
              tooltip: 'Excluir',
              icon: 'pi pi-fw pi-trash',
              iconClass: 'error',
              command: (event, data) => {
                this.confirmationService.confirm({
                  header: 'Excluir Análise',
                  message: `Deseja excluir a análise ?`,
                  accept: () => {
                    this.analiseFacade.delete(data.id).subscribe(() => {
                      this.load();
                    });
                  },
                });
              },
          },
          {
            tooltip: 'Requisitar Análise',
            icon: 'pi pi-fw pi-file',
            iconClass: 'success',
            routerLink: `/app/analises/results/${analise.id}`
          }
      ] as Action[],
    };
  }
}
