import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/Models/product';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from '../../../Services/product.service';
import { AlertifyService } from '../../../Services/alertify.service';
import { Validators, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() productItem:Product

  constructor(
    private cartService: CartService,
    private productService: ProductService,
    private alertifyService: AlertifyService,
  ) { }

  ngOnInit(): void {
  }
 
  productForm = new FormGroup(
    {
      quantity: new FormControl(1,[Validators.required,Validators.min(1),Validators.max(10)])
    }
  );

  handleAddToCart() {
    if (this.productItem.items == null) {
      this.productItem.items = this.productForm.get('quantity').value;
    }
    if (this.cartService.sendCart(this.productItem)) {
      this.alertifyService.success("Product added to cart")
    } else {
      this.alertifyService.error("Product already added")
    }
  }

  viewProductDetails() {
    this.productService.setProduct(this.productItem.productId)
  }

  get quantity() {
    return this.productForm.get('quantity')
  }
}
