import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from '../Models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems = [];

  constructor() { }

  sendCart(productItem: Product) {
    this.cartItems.push(productItem)
    this.sendCartToLocal(this.cartItems)
  }

  getCartItems() {
    this.cartItems = []
    return this.cartItems = this.getCartfromLocal()
  }

  getNumberOfItems() {
    this.cartItems = []
    this.cartItems = this.getCartfromLocal()
    return this.cartItems.length
  }

  removeItems(id: number) {
    this.cartItems = []
    this.cartItems = this.getCartfromLocal()
    this.cartItems.splice(this.cartItems.findIndex(x => x.productId === id), 1)
    this.sendCartToLocal(this.cartItems)    
  }

  sendCartToLocal(cart: any[]) {
    localStorage.setItem("cartItems", JSON.stringify(cart))
  }

  getCartfromLocal(): any[] {
    return JSON.parse(localStorage.getItem("cartItems"))
  }
}
