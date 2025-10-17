import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTableLeafFormComponent } from './nutrient-table-leaf-form.component';

describe('NutrientTableLeafFormComponent', () => {
  let component: NutrientTableLeafFormComponent;
  let fixture: ComponentFixture<NutrientTableLeafFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTableLeafFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTableLeafFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
