import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { FertilizerTable } from '../../models/fertilizer-table.model';

@Injectable({
  providedIn: 'root',
})
export class FertilizerTableService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAllFertilizerTables() {
    return this.httpClient
      .get<FertilizerTable[]>(`${this.fertilizerTablesApiUrl}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getFertilizerTableById(id: string) {
    return this.httpClient
      .get<FertilizerTable>(`${this.fertilizerTablesApiUrl}/by-id/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getFertilizerTableByCulture(cultureId: string) {
    return this.httpClient
      .get<FertilizerTable>(
        `${this.fertilizerTablesApiUrl}/by-culture/${cultureId}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  createFertilizerTable(fertilizerTable: FertilizerTable) {
    return this.httpClient
      .post<FertilizerTable>(
        `${this.fertilizerTablesApiUrl}`,
        JSON.stringify(fertilizerTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  updateFertilizerTable(fertilizerTable: FertilizerTable) {
    return this.httpClient
      .put<FertilizerTable>(
        `${this.fertilizerTablesApiUrl}/${fertilizerTable.id}`,
        JSON.stringify(fertilizerTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  deleteFertilizerTable(id: string) {
    return this.httpClient
      .delete<void>(
        `${this.fertilizerTablesApiUrl}/${id}`,
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }
}
