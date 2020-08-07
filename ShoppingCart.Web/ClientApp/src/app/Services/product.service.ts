import { Injectable } from '@angular/core';
import { Product } from '../Models/product';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, Subject } from 'rxjs';

const apiUrl = "http://localhost:4000/api/product";
const apiProductUrl = "http://localhost:4000/api/product/category?";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private subject = new Subject<Product[]>();

  prodList: Product[] = []

  onProducts(): Observable<Product[]> {
    return this.subject.asObservable();
  }

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(apiUrl)
  }

  setProductsByCategoryId(categoryId: number) {
    let params = new HttpParams().set('categoryId', categoryId.toString())
    this.http.get<Product[]>(apiProductUrl, { params: params }).subscribe((produts) => {
      this.prodList = produts;
      this.subject.next(this.prodList);
    });
  }

}
