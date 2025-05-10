import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  RequestCount=0;
  constructor(private _service: NgxSpinnerService) {}

  loading() {
    this.RequestCount++;
    this._service.show(undefined, {
      bdColor: 'rgba(0, 0, 0, 0.8)',
      size: 'medium',
      color: '#fff',
      type: 'square-jelly-box',
      fullScreen: true
    });
  }
  hideLoader(){
    this.RequestCount--;
    if(this.RequestCount <0){
      this.RequestCount=0;
      this._service.hide();
    }
  }
}
