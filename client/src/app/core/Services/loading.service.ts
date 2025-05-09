import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  constructor(private _service:NgxSpinnerService) { 
    
  }

  loading(){
    this._service.show(undefined, {
      
    });
  }
}
