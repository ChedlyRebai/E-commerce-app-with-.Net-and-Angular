import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { response } from 'express';

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
  categories:any[] = [];
  getCategory(){
    return this.http.get(this.baseUrl).subscribe({
      next: (response:any)=>{
        this.categories = response.data;
        console.log(response);
      }
    })
  }
  ngOnInit(): void {
    this.getCategory();
  }
}
