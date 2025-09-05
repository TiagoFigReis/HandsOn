import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { Culture } from '../../models/culture.model';


@Injectable({
  providedIn: 'root',
})
export class CultureService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAllCultures() {
    return this.httpClient
      .get<Culture[]>(`${this.culturesApiUrl}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getAllCulturesWithoutNutrientTable() {
    return this.httpClient
      .get<Culture[]>(`${this.culturesApiUrl}/no-nutrient-tables`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getAllCulturesWithoutFertilizerTable() {
    return this.httpClient
      .get<Culture[]>(`${this.culturesApiUrl}/no-fertilizer-tables`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getCultureById(id: string) {
    return this.httpClient
      .get<Culture>(`${this.culturesApiUrl}/by-id/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getCultureByName(name: string) {
    return this.httpClient
      .get<Culture>(`${this.culturesApiUrl}/by-name/${name}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  createCulture(culture: Culture) {
    return this.httpClient
      .post<Culture>(`${this.culturesApiUrl}`, JSON.stringify(culture), this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  updateCulture(culture: Culture) {
    return this.httpClient
      .put<Culture>(
        `${this.culturesApiUrl}/${culture.id}`,
        JSON.stringify(culture),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  deleteCulture(id: string) {
    return this.httpClient
      .delete<void>(`${this.culturesApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }
}
