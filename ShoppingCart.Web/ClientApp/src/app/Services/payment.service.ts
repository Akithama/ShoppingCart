import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { userUrl, orderUrl } from 'src/config/api';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Product } from '../Models/product';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient,) { }

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
}
