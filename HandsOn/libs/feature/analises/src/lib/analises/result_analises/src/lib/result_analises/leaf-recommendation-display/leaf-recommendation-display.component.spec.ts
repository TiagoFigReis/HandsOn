import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LeafRecommendationDisplayComponent } from './leaf-recommendation-display.component';

describe('LeafRecommendationDisplayComponent', () => {
  let component: LeafRecommendationDisplayComponent;
  let fixture: ComponentFixture<LeafRecommendationDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeafRecommendationDisplayComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(LeafRecommendationDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
