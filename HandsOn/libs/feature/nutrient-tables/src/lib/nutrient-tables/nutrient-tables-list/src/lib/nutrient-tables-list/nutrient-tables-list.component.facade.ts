import { Injectable } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import {
    NutrientTable,
    NutrientTableFacade,
    ConfirmationService,
    UserRoles,
    CultureFacade,
    Culture,
    UserFacade
} from '@farm/core';
import { Row, Action } from '@farm/ui';

@Injectable({
    providedIn: 'root',
})
export class NutrientTablesListComponentFacade {
    private nutrientTablesSubject = new BehaviorSubject<Row[]>([]);
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private allCultures: Culture[] = [];
    private userRole = '';

    loading$: Observable<boolean> = this.loadingSubject.asObservable();
    nutrientTables$: Observable<Row[]> = this.nutrientTablesSubject.asObservable();

    constructor(
        private nutrientTableFacade: NutrientTableFacade,
        private confirmationService: ConfirmationService,
        private cultureFacade: CultureFacade,
        private userFacade: UserFacade
    ) { }

    load() {
        this.loadingSubject.next(true);

        this.userFacade.me().pipe(
            switchMap(user => {
                this.userRole = user.role as string

                return forkJoin([
                    this.cultureFacade.getAllCultures(),
                    this.nutrientTableFacade.getAllNutrientTables()
                ]);
            }),
            tap({
                next: ([cultures, nutrientTables]) => {
                    this.allCultures = cultures;
                    this.nutrientTablesSubject.next(
                        nutrientTables.map(nutrientTable => this.mapNutrientTableToRow(nutrientTable))
                    );
                    this.loadingSubject.next(false);
                },
                error: () => {
                    this.loadingSubject.next(false);
                }
            })
        ).subscribe();
    }

    private mapNutrientTableToRow(nutrientTable: NutrientTable): Row {
        const { user, culture, leafNutrientRows, soilNutrientRow, standard, ...data } = nutrientTable;

        const newData = {
            ...data,
            cultureName: this.allCultures.find(c => c.id == data.cultureId)?.name ?? "Cultura desconhecida",
            standardText: standard ? "Não" : "Sim"
        };

        const actions: Action[] = [
            {
                tooltip: 'Editar',
                icon: 'pi pi-fw pi-pencil',
                iconClass: 'primary',
                routerLink: `/app/nutrientTables/${nutrientTable.id}`,
                command: () => { return }
            }
        ];

        const deleteText = this.userRole == UserRoles.Admin ?
            `Deseja excluir a tabela de nutrientes de "${newData.cultureName}"?` :
            `Deseja excluir a tabela de nutrientes personalizada de "${newData.cultureName}"?`;

        //Se o usuário não é um admin e standard é true, não inclui a ação de remover
        if (this.userRole != UserRoles.Admin && standard) {;}
        else {
            actions.push({
                tooltip: 'Excluir',
                icon: 'pi pi-fw pi-trash',
                iconClass: 'error',
                command: (event, data) => {
                    this.confirmationService.confirm({
                        header: 'Excluir Tabela',
                        message: deleteText,
                        accept: () => {
                            this.nutrientTableFacade.deleteNutrientTable(data.id).subscribe(() => {
                                this.load();
                            });
                        },
                    });
                },
            });
        }

        return {
            ...newData,
            actions: actions,
        };
    }
}
