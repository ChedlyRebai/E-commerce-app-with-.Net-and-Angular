import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    // Importing RouterModule to use routing features in the shared module
    RouterModule
  ],
  exports: [CommonModule],
})
export class SharedModule {}
