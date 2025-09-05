import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  AnaliseFacade,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AnaliseFormComponentFacade {
    private fileSubject = new BehaviorSubject<Blob | null>(null)

    id: string | undefined;
    file$: Observable<Blob | null> = this.fileSubject.asObservable()
  
    constructor(
      private analiseFacade: AnaliseFacade,
      private router: Router,
    ){}

    getfile(id: string | undefined){
      if(!id){
          this.id = id;
          return
        }

      this.id = id;

      this.fileSubject.next(null)
      
      this.analiseFacade.getFile(id).pipe(
        tap(
          (file) => {
            this.fileSubject.next(file)
          },
          (error) => {
              const code = error.code;
              if (code === 400 || code === 404) this.router.navigate(['/404']);
          },
        ),
      ).subscribe()
    }
}