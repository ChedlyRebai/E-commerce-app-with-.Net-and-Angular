import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket.service';
import { IBasket } from '../../Shared/Moddels/Basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css',
})
export class BasketComponent implements OnInit {
  constructor(private _service: BasketService) {}
  basket: IBasket | null = null;
  ngOnInit(): void {
    this._service.basket$.subscribe(
      (value) => {
        this.basket = value;
        console.log('Basket value:', this.basket);
      },
      (error) => {
        console.error('Error fetching basket:', error);
      }
    );
  }

  changeItemQuantity(itemId: number, event: Event) {
    const quantity = +(event.target as HTMLSelectElement).value;
    console.log('Selected quantity:', quantity);
    console.log('item id', itemId);
    if (this.basket) {
      const item = this.basket.items.find((i) => i.id === itemId);
      if (item) {
        item.quantity = quantity;
        this._service.SetBasket(this.basket);
      }
    }
  }

   removeItemFromBasket(itemId:number){
    console.log('Removing item with ID:', itemId);
    if(this.basket){
      const item=this.basket.items.find((i)=>i.id==itemId);
      if(item){
        this.basket.items =this.basket.items.filter((i)=> i.id !== itemId);
        this._service.SetBasket(this.basket);
        console.log('Item removed from basket:', itemId);
      }
    }
    
  }
}
