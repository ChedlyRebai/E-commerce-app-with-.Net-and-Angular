import { IBasketItem } from "./BasketItem"
import { v4 as uuidv4 } from 'uuid';
export interface IBasket {
  id: string
  items: IBasketItem[]
}


export class Basket implements IBasket {
    id = uuidv4(); // Generate a unique ID for the basket
    items: IBasketItem[] = [];
}