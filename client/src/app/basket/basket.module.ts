import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BasketRoutingModule } from './basket-routing.module';
import { BasketComponent } from './basket/basket.component';
import { SharedModule } from '../Shared/shared.module';
import { OrderTotalComponent } from '../Shared/Component/order-total/order-total.component';


@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    BasketRoutingModule,
  
    SharedModule
  ]
})
export class BasketModule { }
