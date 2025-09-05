import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { DadosAnalise, RecommendFertilizers } from '../../models/analise.model';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';

@Injectable({
  providedIn: 'root',
})
export class dataAnalyseService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  AnalyseNutrients(data : DadosAnalise){
    return this.httpClient.post<DadosAnalise>(`${this.dataAnalysisApiUrl}/analyseNutrients`,JSON.stringify(data), this.httpOptions)
    .pipe(catchError(this.handleError));
  }

  RecommendFertilizers(data : RecommendFertilizers){
    return this.httpClient.post<RecommendFertilizers>(`${this.dataAnalysisApiUrl}/recommendFertilizers`,JSON.stringify(data), this.httpOptions)
    .pipe(catchError(this.handleError));
  }
}