import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
  UsersListComponentFacade,
  UserWithActions,
} from './users-list.component.facade';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-users-list',
  imports: [CommonModule, RouterLink, ButtonComponent],
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.css',
})
export class UsersListComponent implements OnInit {
  data: UserWithActions[] = [];
  loading = false;

  constructor(private facade: UsersListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.users$.subscribe((users) => {
      this.data = users;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}