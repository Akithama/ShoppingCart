import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedComponent } from './shared.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';

const routes: Routes = [
  { path: '', component: SharedComponent },
  { path: 'nav/nav', component: NavComponent },
  { path: 'footer/footer', component: FooterComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }
