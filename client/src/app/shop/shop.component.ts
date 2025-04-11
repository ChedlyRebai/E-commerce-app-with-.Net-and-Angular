import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { response } from 'express';
import { IPagination } from '../Shared/Moddels/Pagination';
import { IProduct } from '../Shared/Moddels/Product';
import { ICategory } from '../Shared/Moddels/Category';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {
  constructor(private shopService:ShopService){

  }
  products:IProduct[]=[]
  categories:ICategory[]=[];
  ngOnInit(): void {
   this.getAllProducts();
   this.getAllCategories();
  console.log(this.categories);
  }

  getAllProducts(){
    this.shopService.getProducts().subscribe(
      {
        next:(response:IPagination)=>{
          this.products= response.data;
        }
      }
    )
  }

  getAllCategories(){
    this.shopService.getCategories().subscribe({
      next:(response:ICategory[])=>{
        this.categories = response;
      }
    });

  }
}
