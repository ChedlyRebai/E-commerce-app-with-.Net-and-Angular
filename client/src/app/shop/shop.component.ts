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
    this.shopService.getProducts(this.categoryId).subscribe(
      {
        next:(response:IPagination)=>{
          this.products= response.data;
          console.log(this.products);
        }
      }
    )
  }

  categoryId:number=0;
  getAllCategories(){

    this.shopService.getCategories().subscribe({
      next:(response:ICategory[])=>{
        this.categories = response;
      }
    });

  }



  selectedId(categoryId:number){
    this.categoryId=categoryId;
    console.log(this.categoryId);
    this.getAllProducts();
  }


  SortingOptions =[
    {name:'Price: Low to High',value:'priceAsc'},
    {name:'Price: High to Low',value:'priceDesc'},
    {name:'Name: A to Z',value:'nameAsc'},
    {name:'Name: Z to A',value:'nameDesc'},
  ]
}
