import { TestBed } from '@angular/core/testing';

import { NutrientTableService } from './nutrient-table.service';

describe('NutrientTableService', () => {
  let service: NutrientTableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NutrientTableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
