import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormulationTablesComponent } from './formulation-tables.component';

describe('FormulationTablesComponent', () => {
  let component: FormulationTablesComponent;
  let fixture: ComponentFixture<FormulationTablesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormulationTablesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FormulationTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
