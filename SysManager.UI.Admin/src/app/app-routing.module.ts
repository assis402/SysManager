import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { RecoveryComponent } from './components/account/recovery/recovery.component';
import { RegisterComponent } from './components/account/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DefaultLayoutComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path:'account',
        loadChildren: ()=>
        import('./components/account/account.module').then((m) => m.AccountModule)
      },
      {
        path:'dashboard',
        loadChildren: ()=>
        import('./components/dashboard/dashboard.module').then((m) => m.DashboardModule)
      },
      {
        path:'unity',
        loadChildren: ()=>
        import('./components/unity/unity.module').then((m) => m.UnityModule)
      },
      {
        path:'product',
        loadChildren: ()=>
        import('./components/product/product.module').then((m) => m.ProductModule)
      },
      {
        path:'product-type',
        loadChildren: ()=>
        import('./components/product-type/product-type.module').then((m) => m.ProductTypeModule)
      },
      {
        path:'category',
        loadChildren: ()=>
        import('./components/category/category.module').then((m) => m.CategoryModule)
      }
    ]
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register'
    }
  },
  {
  path: 'login',
  component: LoginComponent,
  data: {
    title: 'Login'
    }
  },
  {
    path: 'recovery',
    component: RecoveryComponent,
    data: {
      title: 'Recovery'
    }
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    data: {
      title: 'Dashboard'
    }
  }

  //{path: '**', redirectTo: 'dashboard'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'top',
      anchorScrolling: 'enabled',
      initialNavigation: 'enabledBlocking'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
