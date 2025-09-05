import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTableComponent } from './nutrient-table.component';

describe('NutrientTableComponent', () => {
  let component: NutrientTableComponent;
  let fixture: ComponentFixture<NutrientTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTableComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
