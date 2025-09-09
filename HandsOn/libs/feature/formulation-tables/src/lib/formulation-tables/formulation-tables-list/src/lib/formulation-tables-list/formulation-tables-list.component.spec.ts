import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormulationTablesListComponent } from './formulation-tables-list.component';

describe('FormulationTablesListComponent', () => {
  let component: FormulationTablesListComponent;
  let fixture: ComponentFixture<FormulationTablesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormulationTablesListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FormulationTablesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
