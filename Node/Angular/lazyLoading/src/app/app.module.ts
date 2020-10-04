import { NgModule}      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {AppRoutingModule} from './app.routing';

import { AppComponent }  from './app.component';

import{FirstEagerComponent} from './firsteager.component';
import {SecondEagerComponent} from './secondeager.component';

@NgModule({
  imports:      [ BrowserModule,AppRoutingModule],
  declarations: [ 
    AppComponent,
    FirstEagerComponent,
    SecondEagerComponent
     ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
