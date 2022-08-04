import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Guid } from "guid-typescript";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { ProductTypeView } from "../models/product-type-view";
import { ProductTypePost } from "../models/product-type-post";
import { ProductTypePut } from "../models/product-type-put";
import { ProductTypeService } from "../../../services/product-type-service";

@Component({
    selector:'app-product-type-maintenance',
    templateUrl:'./product-type-maintenance.component.html'
})

export class ProductTypeMaintenanceComponent implements OnInit {

@Input() bodyDetail = '';
public modalVisible = false;
productType = new ProductTypeView();
action = 'Inserir';

@Input() id: any = '';
idDefault = Guid.EMPTY;
@Input() urlReturn = '/product-type/product-type';

    constructor(
                private route: ActivatedRoute,
                private router: Router,
                private formBuilder: FormBuilder,
                private activedRouter: ActivatedRoute,
                private productTypeService: ProductTypeService,
                private spinner: NgxSpinnerService,
                private toastr: ToastrService
               ){}

    formProductType = new FormGroup({
                id: this.formBuilder.control(this.productType.id),
                name: this.formBuilder.control(this.productType.name),
                active: this.formBuilder.control(this.productType.active),
               });

    ngOnInit(){
        this.id = this.activedRouter.snapshot.params['id'];
        if (this.id != undefined && this.id != this.idDefault && this.id != null) {
            this.action = 'Alterar';
            this.getById(this.id);
          } else {
            this.action = 'Inserir';
            this.productType = new ProductTypeView();
            this.formProductType.patchValue(this.productType);
          }
    }

    getById(id: string) {
        this.spinner.show();
        this.productTypeService.getByID(id).subscribe(view => {
          this.productType = view;
          this.updateForm(this.productType);
          this.spinner.hide();
        }, error  => {
          this.toastr.error(this.defaultMessage(error), this.action);
          this.spinner.hide();
        });
      }

      updateForm(productType: ProductTypeView){
        this.formProductType = new FormGroup({
          id: this.formBuilder.control(productType.id),
          name: this.formBuilder.control(productType.name),
          active: this.formBuilder.control(productType.active),});
      }

    confirmdelete(){
      if(this.productType.id != undefined && this.productType.id != '')
      {
          this.spinner.show();
          this.productTypeService.delete(this.productType.id).subscribe((response: any) => {
              this.toastr.success(response.message,'Unidade de medida');
              this.spinner.hide();
              this.router.navigateByUrl(this.urlReturn);
              },error => {
                  this.spinner.hide();
                  this.toastr.error(error,'Unidade de medida');
              });
      }
      this.modalVisible = true;
    }

    canceldelete(){
    }

    handleChangeModal(event:any){
    }

    prepareDelete(){
      this.bodyDetail = 'Deseja realmente Excluir o registro ('+this.productType.name+')';
      this.modalVisible = true;
    }
    redirect(url: string) {
        this.router.navigate([url]);
      }

    defaultMessage(message: string): any {
        var string = message.replace('<div>','').
        replace('</div>','').
        replace('<p>','').
        replace('</p>','');
        return string;
      }

      insertProductType(productType: ProductTypeView) {
        this.spinner.show();
        const productTypePost = new ProductTypePost(productType);
        this.productTypeService.insert(productTypePost).subscribe((response: any) =>
           {
            this.spinner.hide();
            this.toastr.success(response.message, this.action);
            this.redirect(this.urlReturn);
           }, error => {
            this.toastr.error(this.defaultMessage(error), this.action);
            this.spinner.hide();
        });
      }

      updateProductType(productType: ProductTypeView) {
        this.spinner.show();
        const productTypePut = new ProductTypePut(productType);
        this.productTypeService.update(productTypePut).subscribe((response: any) =>
           {
             this.spinner.hide();
             this.toastr.success(response.message, this.action);
           }, error => {
             this.toastr.error(this.defaultMessage(error), this.action);
             this.spinner.hide();
          });
      }

      saveChanges(productType: any){
        if (this.productType.id === undefined || this.productType.id === '')
           this.insertProductType(productType);
        else
           this.updateProductType(productType);
    }
}
