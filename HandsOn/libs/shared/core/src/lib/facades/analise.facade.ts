import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AnaliseService } from '../services/analise/analise.service';
import { NotificationService } from '../services/notification/notification.service';
import { Analise } from '../models/analise.model';

@Injectable({
  providedIn: 'root',
})
export class AnaliseFacade {
    private analiseSubject = new BehaviorSubject<Analise | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    analise$: Observable<Analise | null> = this.analiseSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private analiseService: AnaliseService,
      private notificationService: NotificationService,
    ) {}

    getAll(): Observable<Analise[]> {
      return this.analiseService.getAll().pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar as análises!',
            );
          },
        }),
      );
    }

    getById(id: string): Observable<Analise> {
      return this.analiseService.getById(id).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar a análise!',
            );
          },
        }),
      );
    }

    getFile(id: string): Observable<Blob> {
      return this.analiseService.getFile(id).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar o arquivo da análise!',
            );
          },
        }),
      );
    }

    create(analise: Analise): Observable<Analise> {
      return this.analiseService.create(analise).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Análise cadastrada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível cadastrar a análise!',
            );
          },
        }),
      );
    }
  
    update(analise: Analise): Observable<Analise> {
      return this.analiseService.update(analise).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Análise atualizada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível atualizar a análise!',
            );
          },
        }),
      );
    }

    delete(id: string): Observable<void> {
      return this.analiseService.delete(id).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Análise excluída com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível excluir a análise!',
            );
          },
        }),
      );
    }
}