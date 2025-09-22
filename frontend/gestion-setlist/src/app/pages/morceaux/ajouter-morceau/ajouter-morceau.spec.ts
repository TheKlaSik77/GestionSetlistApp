import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AjouterMorceau } from './ajouter-morceau';

describe('AjouterMorceau', () => {
  let component: AjouterMorceau;
  let fixture: ComponentFixture<AjouterMorceau>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AjouterMorceau]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AjouterMorceau);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
