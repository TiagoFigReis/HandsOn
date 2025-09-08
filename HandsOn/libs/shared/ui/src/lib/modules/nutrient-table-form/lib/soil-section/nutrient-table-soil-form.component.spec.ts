import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTableSoilFormComponent } from './nutrient-table-soil-form.component';

describe('NutrientTableSoilFormComponent', () => {
  let component: NutrientTableSoilFormComponent;
  let fixture: ComponentFixture<NutrientTableSoilFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTableSoilFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTableSoilFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
