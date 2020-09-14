import { Component, OnInit, Input, ɵConsole } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/product';
import { Subscription } from 'rxjs';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { CartService } from 'src/app/Services/cart.service';
import { AlertifyService } from 'src/app/Services/alertify.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() product: Product;
  subscription: Subscription;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private alertifyService: AlertifyService) {
    this.subscription = this.productService.onProduct().subscribe(product => {
      if (product) {
        product.specDetails = product.specification.split(',')
        this.product = product;
      } else {
        this.product = null
      }
    });
  }

  productForm = new FormGroup(
    {
      quantity: new FormControl(1, [Validators.required, Validators.min(1),
      (control: AbstractControl) => Validators.max(this.product?.quantity)(control)])
    }
  );

  ngOnInit(): void {
    //this.productService.getProduct().subscribe((products) => {
    //  this.productList = products;
    //})
  }

  addToCart(){
    if (this.product.items == null) {
      this.product.items = this.productForm.get('quantity').value;
    }
    if (this.cartService.sendCart(this.product)) {
      this.alertifyService.success("Product added to cart")
    } else {
      this.alertifyService.error("Product already added")
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  get quantity() {
    return this.productForm.get('quantity')
  }
}
