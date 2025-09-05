import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { NutrientTable, NutrientRow, NutrientColumn } from '../models/nutrient-table.model';
import { NutrientTableService } from '../services/nutrient-table/nutrient-table.service';
import { NotificationService } from '../services/notification/notification.service';

@Injectable({
    providedIn: 'root',
})
export class NutrientTableFacade {
    private nutrientTableSubject = new BehaviorSubject<NutrientTable | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);

    nutrientTable$: Observable<NutrientTable | null> = this.nutrientTableSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    constructor(
        private nutrientTableService: NutrientTableService,
        private notificationService: NotificationService,
    ) { }

    reset(): void {
        this.nutrientTableSubject.next(null);
        this.loadingSubject.next(true);
    }

    getAllNutrientTables(): Observable<NutrientTable[]> {
        return this.nutrientTableService.getAllNutrientTables().pipe(
            tap({
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar as tabelas!',
                    );
                },
            }),
        );
    }

    getNutrientTableById(id: string): Observable<NutrientTable> {
        return this.nutrientTableService.getNutrientTableById(id).pipe(
            tap({
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar a tabela!',
                    );
                },
            }),
        );
    }

    getNutrientTableByCultureType(cultureId: string): Observable<NutrientTable> {
        return this.nutrientTableService.getNutrientTableByCulture(cultureId).pipe(
            tap({
                error: () => {
                    this.notificationService.error(
                        "Erro!",
                        "Não foi possível carregar a tabela!"
                    );
                },
            }),
        );
    }

    createNutrientTable(nutrientTable: NutrientTable): Observable<NutrientTable> {
        return this.nutrientTableService.createNutrientTable(nutrientTable).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Tabela cadastrada com sucesso!',
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível criar a tabela!',
                    );
                },
            }),
        );
    }

    updateNutrientTable(nutrientTable: NutrientTable): Observable<NutrientTable> {
        return this.nutrientTableService.updateNutrientTable(nutrientTable).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Tabela atualizada com sucesso!',
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível atualizar a tabela!',
                    );
                },
            }),
        );
    }

    deleteNutrientTable(id: string): Observable<void> {
        return this.nutrientTableService.deleteNutrientTable(id).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Tabela excluída com sucesso!',
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível excluir a tabela!',
                    );
                },
            }),
        );
    }
}
