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
  selectedSort:string='';
  searchText:string='';
  ngOnInit(): void {
   this.getAllProducts();
   this.getAllCategories();
  console.log(this.categories);
  }

  getAllProducts(){
    this.shopService.getProducts(this.categoryId,this.selectedSort,this.searchText).subscribe(
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
    {name:'Price: Low to High',value:'PriceAsn'},
    {name:'Price: High to Low',value:'PriceDsn'},
    {name:'Name: A to Z',value:'NameAsn'},
    {name:'Name: Z to A',value:'NameDsn'},
  ]

  
  visible:boolean = false;
  ToggleDropDown(){
    this.visible = !this.visible
  }
  
  searchProduct(search:string){
    this.searchText=search;
    this.getAllProducts();
  }

  
  sortingBy(ev:any){
    this.selectedSort=ev;
    this.getAllProducts();
  }

}
