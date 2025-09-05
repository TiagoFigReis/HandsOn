import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTableFormComponent } from './nutrient-table-form.component';

describe('NutrientTableFormComponent', () => {
  let component: NutrientTableFormComponent;
  let fixture: ComponentFixture<NutrientTableFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTableFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTableFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
