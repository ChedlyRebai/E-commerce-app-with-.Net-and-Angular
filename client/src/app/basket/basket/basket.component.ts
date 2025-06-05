import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket.service';
import { IBasket } from '../../Shared/Moddels/Basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent implements OnInit {
  constructor(private _service:BasketService) { }
  basket:IBasket | null = null;
  ngOnInit(): void {
   this._service.basket$.subscribe(
      (value) => {
        this.basket = value;
      },
      (error) => {
        console.error('Error fetching basket:', error);
      }
    );
  }


}
