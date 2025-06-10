import { Component, OnInit } from '@angular/core';
import { IBasket, IBasketTotal } from '../../Moddels/Basket';
import { BasketService } from '../../../basket/basket.service';

@Component({
  selector: 'app-order-total',
  templateUrl: './order-total.component.html',
  styleUrl: './order-total.component.css',
})
export class OrderTotalComponent implements OnInit {
  basketTotal: IBasketTotal | null = null;
  constructor(private basketService: BasketService) {}
  ngOnInit(): void {
    this.basketService.basketTotal$.subscribe({
      next: (value) => {
        this.basketTotal = value;
      },
      error: (error) => {
        console.error('Error fetching basket total:', error);
      },
    });
  }
}
