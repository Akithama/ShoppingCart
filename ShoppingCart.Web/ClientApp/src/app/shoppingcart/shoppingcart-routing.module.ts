import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ShoppingcartComponent } from './shoppingcart.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path: '', component: ShoppingcartComponent },
  { path: 'product-details/product-details', component: ProductDetailsComponent },
  { path: 'cart/cart', component: CartComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShoppingcartRoutingModule { }
