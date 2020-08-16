import { Injectable } from '@angular/core';
import { Product } from '../Models/product';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, Subject } from 'rxjs';
import { productUrl } from '../../config/api';

const apiProductUrl = "http://localhost:4000/api/product/category?";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private subject = new Subject<Product[]>();
  private productDetail = new Subject<Product>();

  prodList: Product[] = []

  constructor(private http: HttpClient) { }

  onProducts(): Observable<Product[]> {
    return this.subject.asObservable();
  }

  onProduct(): Observable<Product> {
    return this.productDetail.asObservable();
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(productUrl)
  }

  //getProduct(): Observable<Product> {
  //  return this.http.get<Product>(apiUrl)
  //}

  setProductsByCategoryId(categoryId: number) {
    let params = new HttpParams().set('categoryId', categoryId.toString())
    this.http.get<Product[]>(apiProductUrl, { params: params }).subscribe((produts) => {
      this.prodList = produts;
      this.subject.next(this.prodList);
    });
  }

  setProduct(productId: number) {
    let params = new HttpParams().set('productId', productId.toString())
    this.http.get<Product>(productUrl+'/product', { params: params }).subscribe((product) => {
      this.productDetail.next(product)
    })
  }
}
