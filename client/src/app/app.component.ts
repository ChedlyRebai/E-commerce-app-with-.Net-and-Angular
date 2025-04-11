import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { response } from 'express';
import { IProduct } from './Shared/Moddels/Product';
import { IPagination } from './Shared/Moddels/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  baseUrl = 'http://localhost:5108/api/Product/get-all';
  constructor(private http:HttpClient){

  }
  products:IProduct[] = [];
  getCategory(){
    return this.http.get<IPagination>(this.baseUrl).subscribe({
      next: (response:IPagination)=>{
        this.products = response.data;
        console.log(response);
      }
    })
  }
  ngOnInit(): void {
    this.getCategory();
  }
}
