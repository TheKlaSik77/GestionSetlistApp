import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BarreRecherche } from './barre-recherche';

describe('BarreRecherche', () => {
  let component: BarreRecherche;
  let fixture: ComponentFixture<BarreRecherche>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BarreRecherche]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BarreRecherche);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
