import { HttpInterceptorFn } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { delay, finalize, Observable } from 'rxjs';
import { LoadingService } from '../Services/loading.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
  constructor(private _service:LoadingService) {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): 
  Observable<HttpEvent<any>> {
    this._service.loading();
    return next.handle(req).pipe(
      delay(1000), // Simulate a delay of 1 second,
      finalize(()=>{
        this._service.hideLoader();
      }))
    
  }
}
