import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NutrientTablesListComponent } from './nutrient-tables-list.component';

describe('NutrientTablesListComponent', () => {
  let component: NutrientTablesListComponent;
  let fixture: ComponentFixture<NutrientTablesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NutrientTablesListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NutrientTablesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
