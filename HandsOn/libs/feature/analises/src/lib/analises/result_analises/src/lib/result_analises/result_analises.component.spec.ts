import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ResultAnalisesComponent } from './result_analises.component';

describe('ResultAnalisesComponent', () => {
  let component: ResultAnalisesComponent;
  let fixture: ComponentFixture<ResultAnalisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ResultAnalisesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ResultAnalisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
