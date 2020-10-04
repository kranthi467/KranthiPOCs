import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouteComponent } from './route/route.component';
import { AdminRoutingModule } from './admin.routing';
import { DetailComponent } from './detail/detail.component';
import { ListComponent } from '.././shared/list/list.component';
import { TableComponent } from '.././shared/table/table.component';
import {MatButtonModule, MatCheckboxModule, MatRadioModule} from '@angular/material';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    FormsModule,
    ReactiveFormsModule,
    MatRadioModule
  ],
  declarations: [RouteComponent, DetailComponent, ListComponent, TableComponent ]
})
export class AdminModule { }
