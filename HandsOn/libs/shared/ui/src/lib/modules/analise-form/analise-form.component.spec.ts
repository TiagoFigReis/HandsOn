import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnaliseFormComponent } from './analise-form.component';

describe('AnaliseFormComponent', () => {
  let component: AnaliseFormComponent;
  let fixture: ComponentFixture<AnaliseFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnaliseFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnaliseFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
