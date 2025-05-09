import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';


const routes:Routes = [
  {path: "",component:ShopComponent},
  {path:"product-details/:id",component:ProductDetailComponent},
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],exports:[
    RouterModule
  ]
})
export class ShopRoutingModule { }
