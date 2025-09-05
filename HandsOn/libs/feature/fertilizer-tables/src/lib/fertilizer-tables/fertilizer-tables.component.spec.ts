import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTablesComponent } from './fertilizer-tables.component';

describe('FertilizerTablesComponent', () => {
  let component: FertilizerTablesComponent;
  let fixture: ComponentFixture<FertilizerTablesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTablesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
