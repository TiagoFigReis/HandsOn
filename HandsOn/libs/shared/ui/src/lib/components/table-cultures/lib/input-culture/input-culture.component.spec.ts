import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InputCultureComponent } from './input-culture.component';

describe('InputCultureComponent', () => {
  let component: InputCultureComponent;
  let fixture: ComponentFixture<InputCultureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputCultureComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(InputCultureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
