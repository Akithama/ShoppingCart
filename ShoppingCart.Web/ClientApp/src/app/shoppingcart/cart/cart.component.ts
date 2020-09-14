import { Component, OnInit } from '@angular/core';
import { CartService } from '../../Services/cart.service';
import { Product } from '../../Models/product';
import { FormGroup, FormControl, AbstractControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems: Product[]
  cartTotal = 0
  payment: any = {}
  discount: number = 0

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

  getTotal() {
    let total = 0;

    for (let i = 0; i < this.cartItems.length; i++) {
      if (this.cartItems[i].price) {
        total += this.cartItems[i].price * this.cartItems[i].items;
      }
    }
    return total;
  }

  getGrandTotal() {
    return this.getTotal() - this.discount;
  }

  setDiscount(code: string) {
    let discount = 10;
    let amount = 0;

    console.log(code)
    this.discount = 10
    //return discount;
  }

  getDiscountAmont() {
    return this.discount;
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
