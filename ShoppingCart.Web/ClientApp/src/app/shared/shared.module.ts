import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { SharedComponent } from './shared.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { NavComponent } from './nav/nav.component';
import { AlertComponent } from './alert/alert.component';

@NgModule({
  declarations: [SharedComponent, FooterComponent, HeaderComponent,NavComponent, AlertComponent],
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  exports:[
    NavComponent,
    FooterComponent,
    SharedComponent,
    AlertComponent
  ]
})
export class SharedModule { }
