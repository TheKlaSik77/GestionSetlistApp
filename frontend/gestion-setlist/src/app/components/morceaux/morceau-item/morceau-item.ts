import { Component, input } from '@angular/core';
import { Morceau } from '../../../models/morceau';

@Component({
  selector: 'app-morceau-item',
  imports: [],
  templateUrl: './morceau-item.html',
  styleUrl: './morceau-item.scss'
})
export class MorceauItem {
  morceau = input.required<Morceau>();


}
