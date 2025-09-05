import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTablesComponent } from './nutrient-tables.component';

describe('NutrientTablesComponent', () => {
  let component: NutrientTablesComponent;
  let fixture: ComponentFixture<NutrientTablesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTablesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
