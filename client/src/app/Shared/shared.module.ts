import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OrderTotalComponent } from './Component/order-total/order-total.component';

@NgModule({
  declarations: [
    OrderTotalComponent
  ],
  imports: [
    CommonModule,
    // Importing RouterModule to use routing features in the shared module
    RouterModule
  ],
  exports: [CommonModule,OrderTotalComponent, ],
})
export class SharedModule {}
