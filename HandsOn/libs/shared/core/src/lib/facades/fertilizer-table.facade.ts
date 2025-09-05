import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { FertilizerTable } from '../models/fertilizer-table.model';
import { FertilizerTableService } from '../services/fertilizer-table/fertilizer-table.service';
import { NotificationService } from '../services/notification/notification.service';

@Injectable({
    providedIn: 'root',
})
export class FertilizerTableFacade {
    private fertilizerTableSubject = new BehaviorSubject<FertilizerTable | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);

    fertilizerTable$: Observable<FertilizerTable | null> = this.fertilizerTableSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    constructor(
        private fertilizerTableService: FertilizerTableService,
        private notificationService: NotificationService,
    ) { }

    reset(): void {
        this.fertilizerTableSubject.next(null);
        this.loadingSubject.next(true);
    }

    getAllFertilizerTables(): Observable<FertilizerTable[]> {
        return this.fertilizerTableService.getAllFertilizerTables().pipe(
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

    getFertilizerTableById(id: string): Observable<FertilizerTable> {
        return this.fertilizerTableService.getFertilizerTableById(id).pipe(
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

    getFertilizerTableByCultureType(cultureId: string): Observable<FertilizerTable> {
        return this.fertilizerTableService.getFertilizerTableByCulture(cultureId).pipe(
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

    createFertilizerTable(fertilizerTable: FertilizerTable): Observable<FertilizerTable> {
        return this.fertilizerTableService.createFertilizerTable(fertilizerTable).pipe(
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

    updateFertilizerTable(fertilizerTable: FertilizerTable): Observable<FertilizerTable> {
        return this.fertilizerTableService.updateFertilizerTable(fertilizerTable).pipe(
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

    deleteFertilizerTable(id: string): Observable<void> {
        return this.fertilizerTableService.deleteFertilizerTable(id).pipe(
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
