import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { NotificationService } from '../services/notification/notification.service';
import { FormulationTable } from '../models/formulation-table.model';
import { FormulationTableService } from '../services/formulation-table/formulation-table.service';

@Injectable({
    providedIn: 'root',
})
export class FormulationTableFacade {
    private formulationTableSubject = new BehaviorSubject<FormulationTable | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);

    formulationTable$: Observable<FormulationTable | null> = this.formulationTableSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    constructor(
        private formulationTableService: FormulationTableService,
        private notificationService: NotificationService,
    ) { }

    reset(): void {
        this.formulationTableSubject.next(null);
        this.loadingSubject.next(true);
    }

    getAllFormulationTables(): Observable<FormulationTable[]> {
        return this.formulationTableService.getAllFormulationTables().pipe(
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

    getFormulationTableById(id: string): Observable<FormulationTable> {
        return this.formulationTableService.getFormulationTableById(id).pipe(
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

    getFormulationTableByCultureType(cultureId: string): Observable<FormulationTable> {
        return this.formulationTableService.getFormulationTableByCulture(cultureId).pipe(
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

    createFormulationTable(formulationTable: FormulationTable): Observable<FormulationTable> {
        return this.formulationTableService.createFormulationTable(formulationTable).pipe(
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

    updateFormulationTable(formulationTable: FormulationTable): Observable<FormulationTable> {
        return this.formulationTableService.updateFormulationTable(formulationTable).pipe(
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

    deleteFormulationTable(id: string): Observable<void> {
        return this.formulationTableService.deleteFormulationTable(id).pipe(
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