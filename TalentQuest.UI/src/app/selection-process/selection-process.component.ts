import { Component } from '@angular/core';
import {FormControl} from '@angular/forms';
@Component({
  selector: 'app-selection-process',
  templateUrl: './selection-process.component.html',
  styleUrls: ['./selection-process.component.scss'],
})
export class SelectionProcessComponent {
  toppings = new FormControl('');
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
}
