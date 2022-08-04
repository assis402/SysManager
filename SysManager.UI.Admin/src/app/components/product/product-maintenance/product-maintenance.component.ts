import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Guid } from "guid-typescript";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { ProductView } from "../models/product-view";
import { ProductPost } from "../models/product-post";
import { ProductPut } from "../models/product-put";
import { ProductService } from "../../../services/product-service";

@Component({
    selector:'app-product-maintenance',
    templateUrl:'./product-maintenance.component.html'
})

export class ProductMaintenanceComponent implements OnInit {

@Input() bodyDetail = '';
public modalVisible = false;
product = new ProductView();
action = 'Inserir';

@Input() id: any = '';
idDefault = Guid.EMPTY;
@Input() urlReturn = '/product/product';

    constructor(
                private route: ActivatedRoute,
                private router: Router,
                private formBuilder: FormBuilder,
                private activedRouter: ActivatedRoute,
                private productService: ProductService,
                private spinner: NgxSpinnerService,
                private toastr: ToastrService
               ){}

    formProduct = new FormGroup({
                id: this.formBuilder.control(this.product.id),
                name: this.formBuilder.control(this.product.name),
                productCode: this.formBuilder.control(this.product.productCode),
                categoryId: this.formBuilder.control(this.product.categoryId),
                productTypeId: this.formBuilder.control(this.product.productTypeId),
                unityId: this.formBuilder.control(this.product.unityId),
                price: this.formBuilder.control(this.product.price),
                percentage: this.formBuilder.control(this.product.percentage),
                costPrice: this.formBuilder.control(this.product.costPrice),
                active: this.formBuilder.control(this.product.active),
               });

    ngOnInit(){
        this.id = this.activedRouter.snapshot.params['id'];
        if (this.id != undefined && this.id != this.idDefault && this.id != null) {
            this.action = 'Alterar';
            this.getById(this.id);
          } else {
            this.action = 'Inserir';
            this.product = new ProductView();
            this.formProduct.patchValue(this.product);
          }
    }

    getById(id: string) {
        this.spinner.show();
        this.productService.getByID(id).subscribe(view => {
          this.product = view;
          this.updateForm(this.product);
          this.spinner.hide();
        }, error  => {
          this.toastr.error(this.defaultMessage(error), this.action);
          this.spinner.hide();
        });
      }

      updateForm(product: ProductView){
        this.formProduct = new FormGroup({
          id: this.formBuilder.control(product.id),
          name: this.formBuilder.control(product.name),
          active: this.formBuilder.control(product.active),});
      }

    confirmdelete(){
      if(this.product.id != undefined && this.product.id != '')
      {
          this.spinner.show();
          this.productService.delete(this.product.id).subscribe((response: any) => {
              this.toastr.success(response.message,'Produto');
              this.spinner.hide();
              this.router.navigateByUrl(this.urlReturn);
              },error => {
                  this.spinner.hide();
                  this.toastr.error(error,'Produto');
              });
      }
      this.modalVisible = true;
    }

    canceldelete(){
    }

    handleChangeModal(event:any){
    }

    prepareDelete(){
      this.bodyDetail = 'Deseja realmente Excluir o registro ('+this.product.name+')';
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

      insertProduct(product: ProductView) {
        this.spinner.show();
        const productPost = new ProductPost(product);
        this.productService.insert(productPost).subscribe((response: any) =>
           {
            this.spinner.hide();
            this.toastr.success(response.message, this.action);
            this.redirect(this.urlReturn);
           }, error => {
            this.toastr.error(this.defaultMessage(error), this.action);
            this.spinner.hide();
        });
      }

      updateProduct(product: ProductView) {
        this.spinner.show();
        const productPut = new ProductPut(product);
        this.productService.update(productPut).subscribe((response: any) =>
           {
             this.spinner.hide();
             this.toastr.success(response.message, this.action);
           }, error => {
             this.toastr.error(this.defaultMessage(error), this.action);
             this.spinner.hide();
          });
      }

      saveChanges(product: any){
        if (this.product.id === undefined || this.product.id === '')
           this.insertProduct(product);
        else
           this.updateProduct(product);
    }
}
