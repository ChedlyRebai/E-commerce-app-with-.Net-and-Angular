import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../../Shared/Moddels/Product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {
 
  constructor(private shopService:ShopService,private route:ActivatedRoute){
   

  } 
  product :IProduct | undefined;
  ngOnInit(): void {
    this.loadProduct()
  }

  loadProduct(){
    this.shopService.getProductById(parseInt(this.route.snapshot.paramMap.get('id')|| ""))
    .subscribe({
      next:((value:IProduct)=>{
        this.product = value;
        console.log(this.product);
      })
    })
    
  }
}
