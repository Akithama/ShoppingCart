import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'registration', loadChildren: () => import('./registration/registration.module').
                                        then(m => m.RegistrationModule) },
  { path: 'shoppingcart', loadChildren: () => import('./shoppingcart/shoppingcart.module').then(m => m.ShoppingcartModule) },
  { path: 'shared', loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
