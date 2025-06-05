import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Basket, IBasket } from '../Shared/Moddels/Basket';
import { IProduct } from '../Shared/Moddels/Product';
import { IBasketItem } from '../Shared/Moddels/BasketItem';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  constructor(private http: HttpClient) {}
  BaseUrl = 'http://localhost:5108/api/';
  private basketSource = new BehaviorSubject<IBasket | null>(null);
  basket = this.basketSource.asObservable();

  GetBasket(id: string) {
    return this.http
      .get<IBasket>(this.BaseUrl + 'Basket/get-basket-item/' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
        })
      );
  }

  SetBasket(basket: IBasket) {
    return this.http
      .post<IBasket>(this.BaseUrl + 'Basket/update-basket', basket)
      .subscribe((response: IBasket) => {
        this.basketSource.next(response);
      });
  }

  GetCurrentValue(){
    return this.basketSource.value;
  }

  addItemToBasket(product:IProduct,quantity:number=1){
    const itemToADD:IBasketItem = this.mapProductToBasketItem(product, quantity);
    const basket = this.GetCurrentValue() ?? this.createBasket();
    basket.BasketItems = this.addOrUpdateItem(basket.BasketItems, itemToADD,quantity);
    this.SetBasket(basket);
  }

  addOrUpdateItem(BasketItems: IBasketItem[], itemToADD: IBasketItem, quantity: number): IBasketItem[] {
    const index= BasketItems.findIndex(
      (item) => item.id === itemToADD.id
    );

    if(index === -1) {
      itemToADD.quantity = quantity;
      BasketItems.push(itemToADD);
    }else{
      BasketItems[index].quantity += quantity;
    }
    return BasketItems;

  }

  private  createBasket(): IBasket  {
    const basket= new Basket();
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
    }
  }
}
