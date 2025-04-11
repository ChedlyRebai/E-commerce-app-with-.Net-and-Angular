import { Injectable } from '@angular/core';
import { IProduct } from '../Shared/Moddels/Product';
import { IPagination } from '../Shared/Moddels/Pagination';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  
  baseUrl = 'http://localhost:5108/api/';
  constructor(private http:HttpClient){

  }
  products:IProduct[] = [];
  getProducts(){
    return this.http.get<IPagination>(this.baseUrl+"Product/get-all");
  }
 
}
