import { inject, Injectable } from '@angular/core';
import { HttpContext, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { APP_CONFIG } from '../../config/app-config.token';

@Injectable({
  providedIn: 'root',
})
export class RequestService {
  private readonly appConfig = inject(APP_CONFIG);

  authApiUrl = '';
  usersApiUrl = '';
  analiseApiUrl = '';
  dataAnalysisApiUrl = '';
  nutrientTablesApiUrl = '';
  fertilizerTablesApiUrl = '';
  culturesApiUrl = '';

  public constructor(
    public httpClient: HttpClient,
    public router: Router,
    public jwtHelper: JwtHelperService,
  ) {
    this.authApiUrl = this.appConfig.authApiUrl;
    this.usersApiUrl = this.appConfig.usersApiUrl;
    this.analiseApiUrl = this.appConfig.analiseApiUrl;
    this.dataAnalysisApiUrl = this.appConfig.dataAnalysisApiUrl;
    this.nutrientTablesApiUrl = this.appConfig.nutrientTablesApiUrl;
    this.fertilizerTablesApiUrl = this.appConfig.fertilizerTablesApiUrl;
    this.culturesApiUrl = this.appConfig.culturesApiUrl;
  }

  public httpOptions: {
    headers?: HttpHeaders;
    context?: HttpContext;
  } = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
    }),
  };

  public handleError(error: HttpErrorResponse) {
    const errorMessage = {
      code: error.status,
      message: '',
      errors: [],
    };

    if (error.status === 404 || error.status === 403)
      this.router.navigate(['/404']);

    if (error.error instanceof ErrorEvent) {
      errorMessage.message = error.error.message;
    } else {
      errorMessage.message = error.message;
      errorMessage.errors = error.error.errors;
    }

    return throwError(errorMessage);
  }
}
