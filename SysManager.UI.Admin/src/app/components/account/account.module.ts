import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule, CardModule, FormModule, GridModule, ToastModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { RegisterComponent } from './register/register.component';
import {AccountRoutingModule} from './account-routing.module'
import { LoginComponent } from './login/login.component';
import { RecoveryComponent } from './recovery/recovery.component';

@NgModule(
  {
    declarations: [
      RegisterComponent,
      LoginComponent,
      RecoveryComponent
    ],
    imports: [
      AccountRoutingModule,
      CommonModule,
      CardModule,
      ButtonModule,
      ToastModule,
      GridModule,
      IconModule,
      FormModule,
    ]
  }
)
export class AccountModule{};
