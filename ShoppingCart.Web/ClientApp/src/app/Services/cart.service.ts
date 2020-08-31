import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from '../Models/product';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems = [];

  constructor(private storageService: StorageService) { }

  sendCart(productItem: Product): boolean {
    if (!this.cartItems.find(x => x.productId === productItem.productId)) {
      this.cartItems.push(productItem)
      this.sendCartToLocal(this.cartItems)
      return true;
    }
    return false;
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
    //sessionStorage.setItem("cartItems", JSON.stringify(cart))
    sessionStorage.setItem("cartItems", this.storageService.encryptData(cart))
  }

  getCartfromLocal(): any[] {
    if (sessionStorage.getItem("cartItems")!=null) {
    let numberOfItems = this.storageService.decryptData(sessionStorage.getItem("cartItems"))  //JSON.parse(sessionStorage.getItem("cartItems"))
      if (numberOfItems != null) {
        return this.storageService.decryptData(sessionStorage.getItem("cartItems")) //JSON.parse(sessionStorage.getItem("cartItems"))
      }
    }
    return [];
  }
}
