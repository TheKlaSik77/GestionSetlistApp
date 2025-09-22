import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MorceauItem } from './morceau-item';

describe('MorceauItem', () => {
  let component: MorceauItem;
  let fixture: ComponentFixture<MorceauItem>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MorceauItem]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MorceauItem);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
