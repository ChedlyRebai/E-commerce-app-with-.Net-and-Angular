import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop/shop.component';
import { HomeComponent } from './home/home/home.component';
import { ProductDetailComponent } from './shop/product-detail/product-detail.component';

const routes: Routes = [

  {path:"",component:HomeComponent},
  {path:"shop",loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule)},
 
  {path:"*",redirectTo:"",pathMatch:"full"},
  {path:"basket",loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule)},
   {path:"checkout",loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule)},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
