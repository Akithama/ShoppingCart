import { Component, OnInit, Input } from '@angular/core';
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
        this.product = product;
        //console.log(product)
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
