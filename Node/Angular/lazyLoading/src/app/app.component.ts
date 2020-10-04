import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
  <h1>{{title}}</h1>
  <nav>
    <a routerLink='firsteager'>FirstEagerComponet</a>
    <a routerLink='secondeager'>SecondEagerComponet</a>
    <a routerLink='lazy'>LazyComponent</a>
  </nav>
  <router-outlet></router-outlet>
  `,
})
export class AppComponent  { title="Lazy Loading Demo"; }
