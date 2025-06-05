import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../../Shared/Moddels/Basket';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  count!: Observable<IBasket | null>;
   constructor(private basketService: BasketService) {

  }
  ngOnInit(): void {
    const basket_id = localStorage.getItem('basket_id');
    this.basketService.GetBasket(basket_id || '').subscribe({
      next: (basket:any) => {
        console.log(basket);
        this.count = this.basketService.basket$;
        console.log('Basket count:', this.count);
      },
      error: (error) => {
        console.error('Error fetching basket:', error);
      }
    });
  }
  
  visible:boolean = false;
  ToggleDropDown(){
    this.visible = !this.visible
  }

 

}
