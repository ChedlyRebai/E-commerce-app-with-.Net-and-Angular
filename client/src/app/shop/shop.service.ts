import { Injectable } from '@angular/core';
import { IProduct } from '../Shared/Moddels/Product';
import { IPagination } from '../Shared/Moddels/Pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ICategory } from '../Shared/Moddels/Category';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  
  baseUrl = 'http://localhost:5108/api/';
  constructor(private http:HttpClient){

  }
  products:IProduct[] = [];
  categorie:ICategory[]=[];
  getCategories(){
    
    return this.http.get<ICategory[]>(this.baseUrl+"Category/get-all?");
  }
  
  getProducts(categorieId?:number){
    let params = new HttpParams();
    if(categorieId){
      params = params.append('CategoryId', categorieId.toString());
    }
    console.log(params);
    return this.http.get<IPagination>(this.baseUrl+"Product/get-all",{params});
  }

 
}
