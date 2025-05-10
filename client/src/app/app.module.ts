import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { ShopModule } from './shop/shop.module';
import { NgxSpinnerModule } from "ngx-spinner";
import { LoaderInterceptor } from './core/interceptor/loader.interceptor';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      closeButton:true,
      progressBar:true,
      positionClass:'toast-button-right'

    }),
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(
     // withInterceptorsFromDi(),
      withFetch() // Enable fetch API
    ),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
