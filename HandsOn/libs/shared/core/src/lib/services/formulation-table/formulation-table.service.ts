import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { FormulationTable } from '../../models/formulation-table.model';

@Injectable({
  providedIn: 'root',
})
export class FormulationTableService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAllFormulationTables() {
    return this.httpClient
      .get<FormulationTable[]>(`${this.formulationTablesApiUrl}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getFormulationTableById(id: string) {
    return this.httpClient
      .get<FormulationTable>(`${this.formulationTablesApiUrl}/by-id/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getFormulationTableByCulture(cultureId: string) {
    return this.httpClient
      .get<FormulationTable>(
        `${this.formulationTablesApiUrl}/by-culture/${cultureId}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  createFormulationTable(formulationTable: FormulationTable) {
    return this.httpClient
      .post<FormulationTable>(
        `${this.formulationTablesApiUrl}`,
        JSON.stringify(formulationTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  updateFormulationTable(formulationTable: FormulationTable) {
    return this.httpClient
      .put<FormulationTable>(
        `${this.formulationTablesApiUrl}/${formulationTable.id}`,
        JSON.stringify(formulationTable),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  deleteFormulationTable(id: string) {
    return this.httpClient
      .delete<void>(
        `${this.formulationTablesApiUrl}/${id}`,
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }
}
