import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { StorageService } from 'src/app/Services/storage.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { PaymentService } from 'src/app/Services/payment.service';
import { finalize } from 'rxjs/operators';
import { Product } from 'src/app/Models/product';
import { OrderProduct } from 'src/app/Models/orderProduct';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  paymentProductList: OrderProduct[]
  paymentForm: FormGroup

  constructor(
    private storageService: StorageService,
    private alertifyService: AlertifyService,
    private paymentService: PaymentService) { }

  ngOnInit(): void {

    this.paymentForm = new FormGroup({

    })
  }

  onSubmit() {
    
    if (sessionStorage.getItem("cartItems") != null) {
      let numberOfItems = this.storageService.decryptData(sessionStorage.getItem("cartItems"))
      if (numberOfItems != null) {
        this.paymentProductList = this.storageService.decryptData(sessionStorage.getItem("cartItems"))
        .map(({ productId, items,price }) => ({productId, items,price})); //map two properties and assign model
        //console.log(this.paymentProductList)
      }
    }

    let userID = this.storageService.decryptData(sessionStorage.getItem('user_id'))
    this.paymentService.placeOrder(this.paymentProductList,userID)
      .subscribe(
        result => {
          if (result) {
            sessionStorage.removeItem('cartItems')
            this.alertifyService.success('Order Placed successful');
          }
        },
        error => {
          this.alertifyService.error(error);
        });

  }
}
