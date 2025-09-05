import { TestBed } from '@angular/core/testing';

import { FertilizerTableService } from './fertilizer-table.service';

describe('FertilizerTableService', () => {
  let service: FertilizerTableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FertilizerTableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
