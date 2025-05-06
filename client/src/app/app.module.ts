import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ShopModule } from './shop/shop.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    ShopModule,
    TooltipModule.forRoot(),
    PaginationModule.forRoot(),
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient()

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
