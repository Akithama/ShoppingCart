import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/Models/product';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from '../../../Services/product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() productItem:Product

  constructor(private cartService: CartService, private productService: ProductService) { }

  ngOnInit(): void {
  }

  handleAddToCart(){
    this.cartService.sendCart(this.productItem)
  }

  viewProductDetails() {
    this.productService.setProduct(this.productItem.productId)
  }
}
