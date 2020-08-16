import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistrationRoutingModule } from './registration-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../Services/auth.service';
import { TestComponent } from './test/test.component';


@NgModule({
  declarations: [LoginComponent, RegisterComponent, TestComponent],
  providers:[AuthService],
  imports: [
    CommonModule,
    RegistrationRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RegistrationModule { }
