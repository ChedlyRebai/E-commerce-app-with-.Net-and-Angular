import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../../Shared/Moddels/Product';
import { BasketService } from '../../basket/basket.service';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css',
})
export class ProductDetailComponent implements OnInit {
  constructor(
    private shopService: ShopService,
    private route: ActivatedRoute,
    private activatedRoute: ActivatedRoute,
    private basketService: BasketService,
    private toast:ToastrService
  ) {
    // This constructor is used to inject the ShopService and ActivatedRoute services.
    // The ShopService is used to fetch product details, and ActivatedRoute is used to access route parameters.
  }
  product: IProduct | undefined;
  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService
      .getProductById(parseInt(this.route.snapshot.paramMap.get('id') || ''))
      .subscribe({
        next: (value: IProduct) => {
          this.product = value;
          console.log(this.product);
        },
      });
  }

  addToBasket() {
    this.basketService.addItemToBasket(this.product!, 1);
    this.toast.success('Product added to basket successfully!', 'SUCCESS');
    console.log('Product added to basket:', this.product);
  }
}
