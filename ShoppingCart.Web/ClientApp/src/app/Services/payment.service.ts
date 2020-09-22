import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { userUrl, orderUrl } from 'src/config/api';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Order } from '../Models/order';
import { OrderDetail } from '../Models/orderDetail';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient) { }

  placeOrder(paymentUpdate: any, userID: string) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let params = new HttpParams().set('userID', userID)
    let options = { headers: headers, params: params };

    return this.http.post(orderUrl, paymentUpdate, options)
      .pipe(
        map((data: any) => {
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  getOrders(userID: string): Observable<Order[]> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let params = new HttpParams().set('userID', userID)
    let options = { headers: headers, params: params };

    // return this.http.get<Order[]>(orderUrl,options)
    return this.http.get(orderUrl, options)
      .pipe(
        map((data: Order[]) => {
          return data
        })
      )
  }

  getOrderDetail(orderID: string): Observable<OrderDetail[]> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let params = new HttpParams().set('orderID', orderID)
    let options = { headers: headers, params: params };

    return this.http.get<OrderDetail[]>(orderUrl + "/Detail", options)
  }

}
