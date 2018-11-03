import {NgModule} from '@angular/core';
import {RouterModule,Routes} from '@angular/router';

import {DetailComponent} from './detail/detail.component';
import {RouteComponent} from './route/route.component';

const routes:Routes=[
    {
        path:'',
        component:RouteComponent
    },
    {
        path:'detail',
        component:DetailComponent
    }
];

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})

export class AdminRoutingModule{
    
}