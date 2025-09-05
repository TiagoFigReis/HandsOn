import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InputNutrientTableComponent } from './input-nutrient-table.component';

describe('InputNutrientTableComponent', () => {
  let component: InputNutrientTableComponent;
  let fixture: ComponentFixture<InputNutrientTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputNutrientTableComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(InputNutrientTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
