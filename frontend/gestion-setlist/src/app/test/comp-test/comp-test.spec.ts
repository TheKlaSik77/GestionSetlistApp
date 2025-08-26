import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompTest } from './comp-test';

describe('CompTest', () => {
  let component: CompTest;
  let fixture: ComponentFixture<CompTest>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompTest]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompTest);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
