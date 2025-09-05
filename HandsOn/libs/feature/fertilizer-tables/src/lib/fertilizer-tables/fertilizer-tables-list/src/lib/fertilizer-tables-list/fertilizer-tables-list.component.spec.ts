import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTablesListComponent } from './fertilizer-tables-list.component';

describe('FertilizerTablesListComponent', () => {
  let component: FertilizerTablesListComponent;
  let fixture: ComponentFixture<FertilizerTablesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTablesListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTablesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
