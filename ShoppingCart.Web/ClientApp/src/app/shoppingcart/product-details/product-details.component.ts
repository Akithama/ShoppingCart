import { Component, OnInit, Input, ɵConsole } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/product';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() product: Product;
  subscription: Subscription;

  constructor(private productService: ProductService) {
    this.subscription = this.productService.onProduct().subscribe(product => {
      if (product) {
        product.specDetails = product.specification.split(',')
        this.product = product;
      } else {
        this.product = null
      }
    });
  }

  ngOnInit(): void {
    //this.productService.getProduct().subscribe((products) => {
    //  this.productList = products;
    //})
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
