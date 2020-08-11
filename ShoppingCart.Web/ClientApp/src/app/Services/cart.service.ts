import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  subject = new Subject()

  constructor() { }

  sendCart(product){
    this.subject.next(product)
  }

  getCart(){
    return this.subject.asObservable()
  }
}
