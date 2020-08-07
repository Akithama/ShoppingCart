import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';
import { Category } from '../../Models/category';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/product';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  categoryList: Category[] = []
  //prodList: Product[] = []

  constructor(private categoryService: CategoryService, private productService: ProductService) {
  }

  ngOnInit(): void {
    this.categoryService.getProducts().subscribe((categories) => {
      this.categoryList = categories;
      console.log(this.categoryList);
    })
    console.log(this.categoryList);
  }

  getCategoryId(categoryId: number) {

    this.productService.setProductsByCategoryId(categoryId);
  }
}
