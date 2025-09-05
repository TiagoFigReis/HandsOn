import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { Analise } from '../../models/analise.model';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';

@Injectable({
  providedIn: 'root',
})
export class AnaliseService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAll() {
      return this.httpClient
        .get<Analise[]>(`${this.analiseApiUrl}`, this.httpOptions)
        .pipe(catchError(this.handleError));
  }

  getById(id: string) {
    return this.httpClient
      .get<Analise>(`${this.analiseApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getFile(id: string) {
    return this.httpClient.get(`${this.analiseApiUrl}/files/${id}`, {
      ...this.httpOptions,
      responseType: 'blob' as const
    }).pipe(
      catchError(this.handleError)
    );
  }

  create(analise: Analise) {
    const formData = new FormData();
    formData.append('Lab', analise.lab);
    if(analise.tipo){
      formData.append('Tipo', analise.tipo.toString());
    }
    formData.append('Proprietario', analise.proprietario);
    formData.append('Propriedade', analise.propriedade);
    formData.append('DataAnalise', analise.dataAnalise.toString());
    formData.append('Analise', analise.file);
  
    return this.httpClient
      .post<Analise>(`${this.analiseApiUrl}`, formData)
      .pipe(catchError(this.handleError));
  }
  
  update(analise: Analise) {
    const formData = new FormData();
    formData.append('Lab', analise.lab);
    if(analise.tipo){
      formData.append('Tipo', analise.tipo.toString());
    }
    formData.append('Proprietario', analise.proprietario);
    formData.append('Propriedade', analise.propriedade);
    formData.append('DataAnalise', analise.dataAnalise.toString());
    formData.append('Analise', analise.file);

    return this.httpClient
        .put<Analise>(`${this.analiseApiUrl}/${analise.id}`, formData)
        .pipe(catchError(this.handleError));
  }

  delete(id: string) {
    return this.httpClient
      .delete<void>(`${this.analiseApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }
}