import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ProductTypeRoutes } from "./product-type.routing";

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
import { ProductTypeComponent } from "./product-type.component";
import { ProductTypeMaintenanceComponent } from "./product-type-maintenance/product-type-maintenance.component";
import { ProductTypeViewComponent } from "./models/product-type-view-component";
import { CustomModalModule} from '../custom-modal/custom-modal.module'
import {CustomPaginationModule} from '../pagination/custom-pagination.module'
import { ProductTypeService } from "../../services/product-type-service";

@NgModule({
    imports: [
             CommonModule,
             RouterModule.forChild(ProductTypeRoutes),
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
             ToastModule,
             CustomModalModule,
             CustomPaginationModule
            ],
    declarations:[
                  ProductTypeComponent,
                  ProductTypeMaintenanceComponent,
                  ProductTypeViewComponent
            ],
             providers:[
                        ProductTypeService
                       ]
})
export class ProductTypeModule{}
