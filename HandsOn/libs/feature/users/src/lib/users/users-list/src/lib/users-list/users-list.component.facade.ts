import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import {
  User,
  UserFacade,
  ConfirmationService,
  AuthFacade,
  UserRoles,
  UserStatus,
} from '@farm/core';
import { Action } from '@farm/ui';

export type UserWithActions = User & { actions: Action[] };

@Injectable({
  providedIn: 'root',
})
export class UsersListComponentFacade {
  private usersSubject = new BehaviorSubject<UserWithActions[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  userId: string | undefined;
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  users$: Observable<UserWithActions[]> = this.usersSubject.asObservable();

  constructor(
    private authFacade: AuthFacade,
    private userFacade: UserFacade,
    private confirmationService: ConfirmationService,
  ) {}

  load() {
    const data = this.authFacade.decodedToken;

    this.userId = data.nameid;

    this.loadingSubject.next(true);

    this.userFacade
      .getAllUsers()
      .pipe(
        map((users) =>
          users.map((user) => this.mapUserWithActions(user)),
        ),
        tap(
          (users) => {
            this.usersSubject.next(users);
            this.loadingSubject.next(false);
          },
          () => {
            this.loadingSubject.next(false);
          },
        ),
      )
      .subscribe();
  }

  private mapUserWithActions(user: User): UserWithActions {
    return {
      ...user,
      role: UserRoles[user.role as keyof typeof UserRoles],
      status: UserStatus[user.status as keyof typeof UserStatus],
      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/users/${user.id}`,
        },
        user.id !== this.userId
          ? {
              tooltip: 'Excluir',
              icon: 'pi pi-fw pi-trash',
              iconClass: 'error',
              command: (event, data) => {
                this.confirmationService.confirm({
                  header: 'Excluir Usuário',
                  message: `Deseja excluir o usuário ${data.firstName}?`,
                  accept: () => {
                    this.userFacade.deleteUser(data.id).subscribe(() => {
                      this.load();
                    });
                  },
                });
              },
            }
          : null,
      ] as Action[],
    };
  }
}