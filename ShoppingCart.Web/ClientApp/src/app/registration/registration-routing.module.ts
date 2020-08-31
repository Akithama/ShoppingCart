import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TestComponent } from './test/test.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  { path: 'login/login', component: LoginComponent },
  { path: 'register/register', component: RegisterComponent },
  { path: 'profile/profile', component: ProfileComponent},
  { path: 'test/test', component: TestComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrationRoutingModule { }
