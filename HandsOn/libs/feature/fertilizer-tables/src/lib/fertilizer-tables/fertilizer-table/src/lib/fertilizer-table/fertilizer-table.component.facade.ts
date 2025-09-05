import { Injectable } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable } from 'rxjs';
import {
    FertilizerTable,
    FertilizerTableFacade,
    ConfirmationService,
    UserFacade,
    User
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root',
})
export class FertilizerTableComponentFacade {
    private userSubject = new BehaviorSubject<User | null>(null);
    private fertilizerTableSubject = new BehaviorSubject<FertilizerTable | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    id: string | undefined;

    fertilizerTable$: Observable<FertilizerTable | null> = this.fertilizerTableSubject.asObservable();
    user$: Observable<User | null> = this.userSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    originalTable: FertilizerTable | undefined;
    userRole: string = '';

    constructor(
        private fertilizerTableFacade: FertilizerTableFacade,
        private userFacade: UserFacade,
        private confirmationService: ConfirmationService,
        private router: Router,
    ) { }

    load(id: string) {
        this.id = id;

        this.loadingSubject.next(true);

        this.userFacade.me().pipe

        forkJoin({
            user: this.userFacade.me(),
            fertilizerTable: this.fertilizerTableFacade.getFertilizerTableById(id)
        }).subscribe({
            next: ({ user, fertilizerTable }) => {
                this.userSubject.next(user);
                this.userRole = user.role as string;

                this.fertilizerTableSubject.next(fertilizerTable);
                this.originalTable = fertilizerTable;

                this.loadingSubject.next(false);
            },
            error: (error) => {
                const code = error.code;
                if (code === 400 || code === 404) this.router.navigate(['/404']);
            }
        });
    }

    reset() {
        this.fertilizerTableSubject.next(null);
    }

    submit(fertilizerTable: FertilizerTable) {
        let message = '';
        let action = () => { }


        //Caso seja edição
        if (this.id) {
            if (this.userRole == 'Admin') {
                message = `Deseja ${this.id ? 'atualizar' : 'criar'} a tabela?`;
                action = () => (this.id ? this.updateFertilizerTable(fertilizerTable) : this.addFertilizerTable(fertilizerTable));
            }

            else {
                if (this.originalTable?.standard) {
                    message = `Deseja criar uma tabela personalizada?`;
                    action = () => this.addFertilizerTable(fertilizerTable);
                }

                else {
                    message = `Deseja atualizar a tabela personalizada?`;
                    action = () => this.updateFertilizerTable(fertilizerTable);
                }
            }
        }

        //É CRIAÇÃO
        else {
            message = "Deseja criar a tabela?";
            action = () => this.addFertilizerTable(fertilizerTable);
        }

        this.confirmationService.confirm({
            message: message,
            accept: action,
        });
    }

    private addFertilizerTable(fertilizerTable: FertilizerTable) {
        this.fertilizerTableFacade.createFertilizerTable(fertilizerTable as FertilizerTable).subscribe(() => {
            this.router.navigate(['/app/fertilizerTables']);
        });
    }

    private updateFertilizerTable(fertilizerTable: FertilizerTable) {
        this.fertilizerTableFacade.updateFertilizerTable(fertilizerTable).subscribe(() => {

        });
    }
}
