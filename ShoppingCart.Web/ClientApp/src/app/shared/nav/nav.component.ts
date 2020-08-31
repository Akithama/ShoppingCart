import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';
import { Category } from '../../Models/category';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/product';
import { AuthService } from '../../Services/auth.service';
import { CartService } from '../../Services/cart.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  categoryList: Category[] = []

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService,
    public authService: AuthService,
    public cartService: CartService) {
  }

  ngOnInit(): void {
    this.categoryService.getProducts().subscribe((categories) => {
      this.categoryList = categories;
    })
  }

  getCategoryId(categoryId: number) {
    this.productService.setProductsByCategoryId(categoryId);
  }

  logOut() {
    this.authService.logOut();
  }
}
