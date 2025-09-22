import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfosMorceau } from './infos-morceau';

describe('InfosMorceau', () => {
  let component: InfosMorceau;
  let fixture: ComponentFixture<InfosMorceau>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfosMorceau]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfosMorceau);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
