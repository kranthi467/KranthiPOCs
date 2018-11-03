import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouteComponent } from './route/route.component';
import { AdminRoutingModule } from './admin.routing';
import { DetailComponent } from './detail/detail.component';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule
  ],
  declarations: [RouteComponent, DetailComponent]
})
export class AdminModule { }
