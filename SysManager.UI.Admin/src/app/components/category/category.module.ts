import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CategoryRoutes } from "./category.routing";

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
import { CategoryComponent } from "./category.component";
import { CategoryMaintenanceComponent } from "./category-maintenance/category-maintenance.component";
import { CategoryViewComponent } from "./models/category-view-component";
import { CustomModalModule} from '../custom-modal/custom-modal.module'
import {CustomPaginationModule} from '../pagination/custom-pagination.module'
import { CategoryService } from "../../services/category-service";

@NgModule({
    imports: [
             CommonModule,
             RouterModule.forChild(CategoryRoutes),
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
                  CategoryComponent,
                  CategoryMaintenanceComponent,
                  CategoryViewComponent
            ],
             providers:[
                        CategoryService
                       ]
})
export class CategoryModule{}
