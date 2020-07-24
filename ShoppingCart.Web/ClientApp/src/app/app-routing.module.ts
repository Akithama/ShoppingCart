import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './Helpers/auth.guard';

const accountModule = () => import('./registration/registration.module').then(x => x.RegistrationModule);
const dashboardModule = () => import('./shoppingcart/shoppingcart.module').then(x => x.ShoppingcartModule);

const routes: Routes = [
  //{ path: 'registration', loadChildren: () => import('./registration/registration.module').then(m => m.RegistrationModule) },
  { path: 'registration', loadChildren: accountModule },
  //{ path: 'shoppingcart', loadChildren: () => import('./shoppingcart/shoppingcart.module').then(m => m.ShoppingcartModule)},
  { path: 'shoppingcart', loadChildren: dashboardModule },
  { path: 'shared', loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
