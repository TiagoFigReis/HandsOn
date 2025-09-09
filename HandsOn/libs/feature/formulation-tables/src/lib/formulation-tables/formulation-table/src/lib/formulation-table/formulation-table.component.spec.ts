import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormulationTableComponent } from './formulation-table.component';

describe('FormulationTableComponent', () => {
  let component: FormulationTableComponent;
  let fixture: ComponentFixture<FormulationTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormulationTableComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FormulationTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
