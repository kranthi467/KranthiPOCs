import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouteComponent } from './route/route.component';
import { ClientRoutingModule } from './client.routing';
import { DashboardComponent } from './dashboard/dashboard.component';
 

@NgModule({
  imports: [
    CommonModule,
    ClientRoutingModule
  ],
  declarations: [RouteComponent, DashboardComponent]
})
export class ClientModule { }
