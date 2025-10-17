import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTableLeafFormComponent } from './fertilizer-table-leaf-form.component';

describe('FertilizerTableLeafFormComponent', () => {
  let component: FertilizerTableLeafFormComponent;
  let fixture: ComponentFixture<FertilizerTableLeafFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTableLeafFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTableLeafFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
