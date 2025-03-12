import { Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { authGuard } from './core/guards/auth.guard';
import { userIsAuthGuard } from './core/guards/user-is-auth.guard';

export const routes: Routes = [
    {
        path: '',
        component: HomePageComponent
    },
    {
        path: 'communities/explore',
        loadComponent: ()=> import('./pages/explore-page/explore-page.component').then(x=>x.ExplorePageComponent)
    },
    {
        path: 'auth',
        children:[
            {
                path: 'login',
                loadComponent: ()=> import('./pages/login-page/login-page.component').then(x=>x.LoginPageComponent),
                canActivate: [userIsAuthGuard]
            },
            {
                path: 'register',
                loadComponent: ()=> import('./pages/register-page/register-page.component').then(x=>x.RegisterPageComponent),
                canActivate: [userIsAuthGuard]
            },
            {
                path: 'profile',
                component: HomePageComponent,
                canActivate: [authGuard]
            }
        ]
    }
];
