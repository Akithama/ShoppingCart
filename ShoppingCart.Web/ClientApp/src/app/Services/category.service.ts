import { Injectable } from '@angular/core';
import { Category } from '../Models/category';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const apiUrl = "http://localhost:4000/api/category";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  //categories: Category[] = [
  //  new Category(1,'Consumer Electronics'),
  //  new Category(2,'Computer & Office'),
  //  new Category(3,'Jewelry & Accessories'),
  //  new Category(4,'Home & Garden'),
  //  new Category(5,'Bags'),
  //  new Category(6,'Sports')
  //]

  getProducts(): Observable<Category[]> {
    return this.http.get<Category[]>(apiUrl)
  }
  
  //getCategories(): Category[] {
  //  return this.categories;
  //}
  
}
