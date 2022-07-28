import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { UnityRoutes } from "./unity.routing";
import {
    ButtonGroupModule,
    ButtonModule,
    CardModule,
    DropdownModule,
    FormModule,
    GridModule,
    ListGroupModule,
    PaginationModule,
    SharedModule,
    TableModule,
    ModalModule,
    ToastModule,
  } from '@coreui/angular';

import { IconModule } from '@coreui/icons-angular';
import { NgxSpinnerModule } from 'ngx-spinner';
import { UnityComponent } from "./unity.component";
import { UnityMaintenanceComponent } from "./unity-maintenance/unity-maintenance.component";
import { UnityViewComponent } from "./models/unity-view-component";

@NgModule(
  {
    declarations: [

    ],
    imports: [
      CommonModule,
      RouterModule.forChild(UnityRoutes),
      FormModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule,
      ButtonGroupModule,
      ButtonModule,
      SharedModule,
      CardModule,
      GridModule,
      ListGroupModule,
      DropdownModule,
      IconModule,
      TableModule,
      NgxSpinnerModule,
      PaginationModule,
      ModalModule,
      ToastModule
    ],
    providers: [
      UnityComponent,
      UnityMaintenanceComponent,
      UnityViewComponent
    ]
  }
)
export class UnityModule{};
