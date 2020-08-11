import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/Models/product';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() productItem:Product
  
  constructor(private cartService:CartService) { }

  ngOnInit(): void {
  }

  handleAddToCart(){
    this.cartService.sendCart(this.productItem)
  }
}
