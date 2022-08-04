import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ProductRoutes } from "./product.routing";
import { ProductService } from "../../services/product-service"


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
import { ProductComponent } from "./product.component";
import { ProductMaintenanceComponent } from "./product-maintenance/product-maintenance.component";
import { ProductViewComponent } from "./models/product-view-component";
import { CustomModalModule} from '../custom-modal/custom-modal.module'
import {CustomPaginationModule} from '../pagination/custom-pagination.module'

@NgModule({
    imports: [
             CommonModule,
             RouterModule.forChild(ProductRoutes),
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
                  ProductComponent,
                  ProductMaintenanceComponent,
                  ProductViewComponent
            ],
             providers:[
                       ProductService
                       ]
})
export class ProductModule{}
