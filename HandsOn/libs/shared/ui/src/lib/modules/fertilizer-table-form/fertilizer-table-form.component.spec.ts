import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FertilizerTableFormComponent } from './fertilizer-table-form.component';

describe('FertilizerTableFormComponent', () => {
  let component: FertilizerTableFormComponent;
  let fixture: ComponentFixture<FertilizerTableFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FertilizerTableFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FertilizerTableFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
