import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../Shared/Moddels/Product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent implements OnInit {
  
  @Input()
  Product!: IProduct;
  ngOnInit(): void {
    console.log(this.Product);
  }
}
