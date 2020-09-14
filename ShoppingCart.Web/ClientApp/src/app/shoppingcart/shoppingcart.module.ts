import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingcartRoutingModule } from './shoppingcart-routing.module';
import { ShoppingcartComponent } from './shoppingcart.component';
import { FiltersComponent } from './filters/filters.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CartComponent } from './cart/cart.component';
import { ProductItemComponent } from './product-list/product-item/product-item.component';
import { CartItemComponent } from './cart/cart-item/cart-item.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentComponent } from './payment/payment.component';

@NgModule({
  declarations: [
    ShoppingcartComponent,
    FiltersComponent, 
    ProductListComponent, 
    CartComponent, 
    ProductItemComponent,
    CartItemComponent, 
    ProductDetailsComponent, 
    PaymentComponent],
  imports: [
    CommonModule,
    ShoppingcartRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[

  ]
})
export class ShoppingcartModule { }
