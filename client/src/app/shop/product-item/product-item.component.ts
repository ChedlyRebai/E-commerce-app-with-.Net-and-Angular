import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../Shared/Moddels/Product';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent implements OnInit {
  
  @Input()
  Product!: IProduct;

  constructor(private _service:BasketService) {


   }

   SetBaaskeetValue(){
    if(this.Product){
      this._service.addItemToBasket(this.Product,1);
    }
   }
  ngOnInit(): void {
    
  }
}
