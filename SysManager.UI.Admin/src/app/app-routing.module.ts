import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { RecoveryComponent } from './components/account/recovery/recovery.component';
import { RegisterComponent } from './components/account/register/register.component';
import { DefaultLayoutComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
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
        path: 'account',
        loadChildren: () =>
        import('./components/account/account.module').then((m) => m.AccountModule)
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
