import { TestBed } from '@angular/core/testing';

import { FormulationTableService } from './formulation-table.service';

describe('FormulationTableService', () => {
  let service: FormulationTableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormulationTableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
