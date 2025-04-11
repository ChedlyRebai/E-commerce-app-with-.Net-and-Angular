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
  ngOnInit(): void {
 
  }
}
