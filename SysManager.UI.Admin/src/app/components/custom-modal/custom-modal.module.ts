import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ButtonGroupModule, ButtonModule, CardModule, FormModule, GridModule, ModalModule, SharedModule, TableModule } from "@coreui/angular";
import { CustomModalComponent } from "./custom-modal.component";


@NgModule({
    declarations: [CustomModalComponent],
    exports: [CustomModalComponent],
    imports: [
              CommonModule,
              ModalModule,
              FormModule,
              FormsModule,
              ButtonGroupModule,
              ReactiveFormsModule,
              ButtonModule,
              CardModule,
              TableModule,
              SharedModule,
              GridModule
    ]

})
export class CustomModalModule{}