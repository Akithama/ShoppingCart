import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './Helpers/auth.guard';

const accountModule = () => import('./registration/registration.module').then(x => x.RegistrationModule);
const shoppingcart = () => import('./shoppingcart/shoppingcart.module').then(x => x.ShoppingcartModule);

const routes: Routes = [
  { path: '', redirectTo: 'shoppingcart', pathMatch: 'full' },
  { path: 'registration', loadChildren: accountModule },
  { path: 'shoppingcart', loadChildren: shoppingcart },
  { path: 'shared', loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
