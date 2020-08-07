import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/product';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  productList: Product[] = []
  subscription: Subscription;

  constructor(private productService: ProductService) {
    this.subscription = this.productService.onProducts().subscribe(products => {
      if (products) {
        this.productList = products;
      } else {
        this.productList = [];
      }
    });
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.productService.getProducts().subscribe((products) => {
      this.productList = products;
    })
  }

}
