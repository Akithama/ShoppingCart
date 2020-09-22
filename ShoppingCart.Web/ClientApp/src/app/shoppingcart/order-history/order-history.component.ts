import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/Models/order';
import { OrderDetail } from 'src/app/Models/orderDetail';
import { PaymentService } from 'src/app/Services/payment.service';
import { StorageService } from 'src/app/Services/storage.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  orderList: Order[] = []
  orderDetails: OrderDetail[]=[]
  isView: boolean;

  constructor(private storageService: StorageService,private paymentService: PaymentService) {
    this.isView = false
  }

  ngOnInit(): void {
    let userID = this.storageService.decryptData(sessionStorage.getItem('user_id'))
    this.paymentService.getOrders(userID).subscribe((orders) => {
      this.orderList = orders;
      console.log(orders)
    })
  }

  ViewOrderHistory(orderID:any) {
    this.paymentService.getOrderDetail(orderID).subscribe((orderDetails) => {
      this.orderDetails = orderDetails;
      console.log(orderDetails)
    })
    this.isView = true    
  }
}
