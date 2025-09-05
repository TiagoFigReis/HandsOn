import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { NutrientTable } from '../../models/nutrient-table.model';

@Injectable({
  providedIn: 'root',
})
export class NutrientTableService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAllNutrientTables() {
    return this.httpClient
      .get<NutrientTable[]>(`${this.nutrientTablesApiUrl}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getNutrientTableById(id: string) {
    return this.httpClient
      .get<NutrientTable>(`${this.nutrientTablesApiUrl}/by-id/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getNutrientTableByCulture(cultureId: string) {
    return this.httpClient
      .get<NutrientTable>(
        `${this.nutrientTablesApiUrl}/by-culture/${cultureId}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  createNutrientTable(nutrientTable: NutrientTable) {
    return this.httpClient
      .post<NutrientTable>(
        `${this.nutrientTablesApiUrl}`,
        JSON.stringify(nutrientTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  updateNutrientTable(nutrientTable: NutrientTable) {
    return this.httpClient
      .put<NutrientTable>(
        `${this.nutrientTablesApiUrl}/${nutrientTable.id}`,
        JSON.stringify(nutrientTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  deleteNutrientTable(id: string) {
    return this.httpClient
      .delete<void>(
        `${this.nutrientTablesApiUrl}/${id}`,
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }
}
