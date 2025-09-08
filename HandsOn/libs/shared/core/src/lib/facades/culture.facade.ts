import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { NotificationService } from '../services/notification/notification.service';
import { Culture } from '../models/culture.model';
import { CultureService } from '../services/culture/culture.service';

@Injectable({
  providedIn: 'root',
})
export class CultureFacade {
  private cultureSubject = new BehaviorSubject<Culture | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(true);

  culture$: Observable<Culture | null> = this.cultureSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  constructor(
    private cultureService: CultureService,
    private notificationService: NotificationService
  ) {}

  getAllCultures(): Observable<Culture[]> {
    return this.cultureService.getAllCultures().pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar as Culturas!',
          );
        },
      }),
    );
  }

  getAllCulturesWithoutNutrientTable(): Observable<Culture[]> {
    return this.cultureService.getAllCulturesWithoutNutrientTable().pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar as Culturas!',
          );
        },
      }),
    );
  }

  getAllCulturesWithoutFertilizerTable(): Observable<Culture[]> {
    return this.cultureService.getAllCulturesWithoutFertilizerTable().pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar as Culturas!',
          );
        },
      }),
    );
  }

  getCultureById(id: string): Observable<Culture> {
    return this.cultureService.getCultureById(id).pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar a Cultura!',
          );
        },
      }),
    );
  }

  getCultureByName(name: string): Observable<Culture> {
    return this.cultureService.getCultureByName(name).pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar a Cultura!',
          );
        },
      }),
    );
  }

  createCulture(culture: Culture): Observable<Culture> {
    return this.cultureService.createCulture(culture).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Cultura cadastrada com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível criar a Cultura!',
          );
        },
      }),
    );
  }

  updateCulture(culture: Culture): Observable<Culture> {
    return this.cultureService.updateCulture(culture).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Cultura atualizada com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível atualizar a Cultura!',
          );
        },
      }),
    );
  }

  deleteCulture(id: string): Observable<void> {
    return this.cultureService.deleteCulture(id).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Cultura excluída com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível excluir a Cultura!',
          );
        },
      }),
    );
  }
}
