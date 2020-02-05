import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { DetailComponent } from './detail/detail.component';

const routes: Routes = [
    {
        path: 'cause',
        children: [
            {
                path: '',
                pathMatch: 'full',
                redirectTo: '/cause/create'
            },
            {
                path: 'create',
                component: CreateComponent
            },
            {
                path: 'detail/:id',
                component: DetailComponent
            }
        ]
    },
];

export const CauseRoutingModule = RouterModule.forChild(routes);