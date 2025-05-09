import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ShopModule } from './shop/shop.module';
import { NgxSpinnerModule } from "ngx-spinner";
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    NgxSpinnerModule,
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient()

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
