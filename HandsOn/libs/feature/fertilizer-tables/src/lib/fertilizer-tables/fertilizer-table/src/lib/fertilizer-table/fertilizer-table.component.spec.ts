import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTableComponent } from './fertilizer-table.component';

describe('FertilizerTableComponent', () => {
  let component: FertilizerTableComponent;
  let fixture: ComponentFixture<FertilizerTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTableComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
