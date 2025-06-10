import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Basket, IBasket, IBasketTotal } from '../Shared/Moddels/Basket';
import { IProduct } from '../Shared/Moddels/Product';
import { IBasketItem } from '../Shared/Moddels/BasketItem';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  constructor(private http: HttpClient) {}
  
  BaseUrl = 'http://localhost:5108/api/';
  private basketSource = new BehaviorSubject<IBasket | null>(null);
  basket$ = this.basketSource.asObservable();

  private basketSourCeTotal = new BehaviorSubject<IBasketTotal | null>(null);
  basketTotal$= this.basketSourCeTotal.asObservable();

  calculateTotal(){
    const basket=this.GetCurrentValue();
    const shipping =0;
    const subtotal = basket?.items.reduce((sum, item) => {
      return sum + (item.price * item.quantity);
    }, 0) ?? 0;

    const total = subtotal + shipping;
    this.basketSourCeTotal.next({ shipping, subtotal, total });
  }

  

  GetBasket(id: string) {
    return this.http
      .get<IBasket>(this.BaseUrl + 'Basket/get-basket-item/' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotal();
          console.log('Basket retrieved successfully:', basket);
          return basket;
        })
      );
  }

  SetBasket(basket: IBasket) {
    console.log('ssssssssssssssssssssssssssssssss' );
    console.log(basket);
    return this.http
      .post<any>(this.BaseUrl + 'Basket/update-basket', basket)
      .subscribe({
        next: (response) => {
          console.log('Basket updated successfully:', response);
          this.basketSource.next(basket);
        },
        error: (error) => {
          console.error('Error updating basket:', error);
        },
      });
  }

  GetCurrentValue() {
    return this.basketSource.value;
  }

  addItemToBasket(product: IProduct, quantity: number = 1) {
    const itemToADD: IBasketItem = this.mapProductToBasketItem(
      product,
      quantity
    );
    const basket = this.GetCurrentValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(
      basket.items,
      itemToADD,
      quantity
    );
    console.log(basket);
    console.log(itemToADD);
    this.SetBasket(basket);
  }

  addOrUpdateItem(
    BasketItems: IBasketItem[],
    itemToADD: IBasketItem,
    quantity: number
  ): IBasketItem[] {
    const index = BasketItems.findIndex((item) => item.id === itemToADD.id);

    if (index === -1) {
      itemToADD.quantity = quantity;
      BasketItems.push(itemToADD);
    } else {
      BasketItems[index].quantity += quantity;
    }
    return BasketItems;
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    console.log("basket id:"+basket.id);
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  mapProductToBasketItem(product: IProduct, quantity: number): IBasketItem {
    return {
      id: product.id,
      name: product.name,
      image: product.photos[0]?.imageName || '',
      quantity: quantity,
      price: product.newPrice,
      category: product.categoryName,
    };
  }
}
