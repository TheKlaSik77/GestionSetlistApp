import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeMorceaux } from './liste-morceaux';

describe('ListeMorceaux', () => {
  let component: ListeMorceaux;
  let fixture: ComponentFixture<ListeMorceaux>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListeMorceaux]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListeMorceaux);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
