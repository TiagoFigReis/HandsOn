import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TableCulturesComponent } from './table-cultures.component';

describe('TableCulturesComponent', () => {
  let component: TableCulturesComponent;
  let fixture: ComponentFixture<TableCulturesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TableCulturesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(TableCulturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
