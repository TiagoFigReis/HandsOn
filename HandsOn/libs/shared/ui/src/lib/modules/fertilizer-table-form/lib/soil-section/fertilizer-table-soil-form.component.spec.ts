import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTableSoilFormComponent } from './fertilizer-table-soil-form.component';

describe('FertilizerTableSoilFormComponent', () => {
  let component: FertilizerTableSoilFormComponent;
  let fixture: ComponentFixture<FertilizerTableSoilFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTableSoilFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTableSoilFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
