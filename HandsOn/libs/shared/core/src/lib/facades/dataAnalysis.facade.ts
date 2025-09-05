import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { dataAnalyseService } from '../services/dataAnalysis/dataAnalysis.service';
import { NotificationService } from '../services/notification/notification.service';
import { Analise, DadosAnalise, RecommendFertilizers } from '../models/analise.model';

@Injectable({
  providedIn: 'root',
})
export class DataAnalyseFacade {
    private analiseSubject = new BehaviorSubject<Analise | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    analise$: Observable<Analise | null> = this.analiseSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private dataAnalyseService: dataAnalyseService,
      private notificationService: NotificationService,
    ) {}

    AnalyseNutrients(data : DadosAnalise): Observable<DadosAnalise>{
        return this.dataAnalyseService.AnalyseNutrients(data).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível obter os resultados da análise!',
            );
          },
        }),
      );
    }

    RecommendFertilizers(data : RecommendFertilizers): Observable<RecommendFertilizers>{
        return this.dataAnalyseService.RecommendFertilizers(data).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível obter os resultados da análise!',
            );
          },
        }),
      );
    }
}