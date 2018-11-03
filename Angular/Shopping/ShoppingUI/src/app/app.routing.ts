import {NgModule} from '@angular/core';
import {RouterModule,Routes} from '@angular/router';

const routes:Routes=[
    {
        path:'admin',
        loadChildren:'./admin/admin.module#AdminModule'
    },
    {
        path:'client',
        loadChildren:'./client/client.module#ClientModule'
    }
];

@NgModule({

    imports:[RouterModule.forRoot(routes)],
    exports:[RouterModule]
})

export class AppRoutingModule{

}