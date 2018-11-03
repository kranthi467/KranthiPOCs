import {NgModule} from '@angular/core';
import {RouterModule,Routes} from '@angular/router';

import {FirstEagerComponent} from './firsteager.component';
import {SecondEagerComponent} from './secondeager.component';

const routes:Routes=[

    {
        path:'firsteager',
        component:FirstEagerComponent
    },
    {
        path:'secondeager',
        component:SecondEagerComponent
    },
    {
        path:'lazy',
        loadChildren:'/app/lazy.module#LazyModule'
    }
];

@NgModule({

    imports:[RouterModule.forRoot(routes)],
    exports:[RouterModule]
})

export class AppRoutingModule{

}