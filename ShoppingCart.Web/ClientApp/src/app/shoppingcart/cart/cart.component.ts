import { Component, OnInit } from '@angular/core';
import { CartService } from '../../Services/cart.service';
import { Product } from '../../Models/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems: Product[];
  cartTotal = 0

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cartItems = this.cartService.getCartItems()
    console.log(this.cartItems)
  }

  removeItem(Item: Product) {
    this.cartService.removeItems(Item.productId);
    this.cartService.getCartItems();
    this.cartItems = this.cartService.getCartItems()
  }
}
















  //addProductToCart(product: Product) {

  //  let productExists = false

  //  for (let i in this.cartItems) {
  //    if (this.cartItems[i].productId === product.productId) {
  //      this.cartItems[i].qty++
  //      productExists = true;
  //      break;
  //    }
  //  }

  //  if (!productExists) {
  //    this.cartItems.push({
  //      productId: product.productId,
  //      productName: product.productName,
  //      qty: 1,
  //      price: product.price
  //    })
  //  }

  //  this.cartTotal = 0
  //  this.cartItems.forEach(item => {
  //    this.cartTotal += (item.qty * item.price)
  //  })
  //}

  //getUserName() {
  //  return this.cartItems.length
  //}
