import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BarreRechercheEtFiltre } from './barre-recherche-et-filtre';

describe('BarreRechercheEtFiltre', () => {
  let component: BarreRechercheEtFiltre;
  let fixture: ComponentFixture<BarreRechercheEtFiltre>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BarreRechercheEtFiltre]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BarreRechercheEtFiltre);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
