import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AnalisesListComponent } from './analises-list.component';

describe('AnalisesListComponent', () => {
  let component: AnalisesListComponent;
  let fixture: ComponentFixture<AnalisesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnalisesListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AnalisesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
