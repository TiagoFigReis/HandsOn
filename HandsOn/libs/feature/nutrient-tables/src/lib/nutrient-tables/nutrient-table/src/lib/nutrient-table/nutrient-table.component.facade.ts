import { Injectable } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  NutrientTable,
  NutrientTableFacade,
  ConfirmationService,
  UserFacade,
  User
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class NutrientTableComponentFacade {
  private userSubject = new BehaviorSubject<User | null>(null);
  private nutrientTableSubject = new BehaviorSubject<NutrientTable | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  id: string | undefined;

  nutrientTable$: Observable<NutrientTable | null> = this.nutrientTableSubject.asObservable();
  user$: Observable<User | null> = this.userSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  originalTable: NutrientTable | undefined;
  userRole: string = '';

  constructor(
    private nutrientTableFacade: NutrientTableFacade,
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
      nutrientTable: this.nutrientTableFacade.getNutrientTableById(id)
    }).subscribe({
      next: ({ user, nutrientTable }) => {
        this.userSubject.next(user);
        this.userRole = user.role as string;

        this.nutrientTableSubject.next(nutrientTable);
        this.originalTable = nutrientTable;

        this.loadingSubject.next(false);
      },
      error: (error) => {
        const code = error.code;
        if (code === 400 || code === 404) this.router.navigate(['/404']);
      }
    });
  }

  reset() {
    this.nutrientTableSubject.next(null);
  }

  submit(nutrientTable: NutrientTable) {
    let message = '';
    let action = () => { }
    

    //Caso seja edição
    if (this.id) {
      if (this.userRole == 'Admin') {
        message = `Deseja ${this.id ? 'atualizar' : 'criar'} a tabela?`;
        action = () => (this.id ? this.updateNutrientTable(nutrientTable) : this.addNutrientTable(nutrientTable));
      }

      else {
        if (this.originalTable?.standard) {
          message = `Deseja criar uma tabela personalizada?`;
          action = () => this.addNutrientTable(nutrientTable);
        }

        else {
          message = `Deseja atualizar a tabela personalizada?`;
          action = () => this.updateNutrientTable(nutrientTable);
        }
      }
    }

    //É CRIAÇÃO
    else {
      message = "Deseja criar a tabela?";
      action = () => this.addNutrientTable(nutrientTable);
    }

    this.confirmationService.confirm({
      message: message,
      accept: action,
    });
  }

  private addNutrientTable(nutrientTable: NutrientTable) {
    this.nutrientTableFacade.createNutrientTable(nutrientTable as NutrientTable).subscribe(() => {
      this.router.navigate(['/app/nutrientTables']);
    });
  }

  private updateNutrientTable(nutrientTable: NutrientTable) {
    this.nutrientTableFacade.updateNutrientTable(nutrientTable).subscribe(() => {
      
    });
  }
}
