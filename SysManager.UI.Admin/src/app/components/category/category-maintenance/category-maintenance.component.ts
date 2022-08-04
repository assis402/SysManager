import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Guid } from "guid-typescript";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { CategoryView } from "../models/category-view";
import { CategoryPost } from "../models/category-post";
import { CategoryPut } from "../models/category-put";
import { CategoryService } from "../../../services/category-service";

@Component({
    selector:'app-category-maintenance',
    templateUrl:'./category-maintenance.component.html'
})

export class CategoryMaintenanceComponent implements OnInit {

@Input() bodyDetail = '';
public modalVisible = false;
category = new CategoryView();
action = 'Inserir';

@Input() id: any = '';
idDefault = Guid.EMPTY;
@Input() urlReturn = '/category/category';

    constructor(
                private route: ActivatedRoute,
                private router: Router,
                private formBuilder: FormBuilder,
                private activedRouter: ActivatedRoute,
                private categoryService: CategoryService,
                private spinner: NgxSpinnerService,
                private toastr: ToastrService
               ){}

    formCategory = new FormGroup({
                id: this.formBuilder.control(this.category.id),
                name: this.formBuilder.control(this.category.name),
                active: this.formBuilder.control(this.category.active),
               });

    ngOnInit(){
        this.id = this.activedRouter.snapshot.params['id'];
        if (this.id != undefined && this.id != this.idDefault && this.id != null) {
            this.action = 'Alterar';
            this.getById(this.id);
          } else {
            this.action = 'Inserir';
            this.category = new CategoryView();
            this.formCategory.patchValue(this.category);
          }
    }

    getById(id: string) {
        this.spinner.show();
        this.categoryService.getByID(id).subscribe(view => {
          this.category = view;
          this.updateForm(this.category);
          this.spinner.hide();
        }, error  => {
          this.toastr.error(this.defaultMessage(error), this.action);
          this.spinner.hide();
        });
      }

      updateForm(category: CategoryView){
        this.formCategory = new FormGroup({
          id: this.formBuilder.control(category.id),
          name: this.formBuilder.control(category.name),
          active: this.formBuilder.control(category.active),});
      }

    confirmdelete(){
      if(this.category.id != undefined && this.category.id != '')
      {
          this.spinner.show();
          this.categoryService.delete(this.category.id).subscribe((response: any) => {
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
      this.bodyDetail = 'Deseja realmente Excluir o registro ('+this.category.name+')';
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

      insertCategory(category: CategoryView) {
        this.spinner.show();
        const categoryPost = new CategoryPost(category);
        this.categoryService.insert(categoryPost).subscribe((response: any) =>
           {
            this.spinner.hide();
            this.toastr.success(response.message, this.action);
            this.redirect(this.urlReturn);
           }, error => {
            this.toastr.error(this.defaultMessage(error), this.action);
            this.spinner.hide();
        });
      }

      updateCategory(category: CategoryView) {
        this.spinner.show();
        const categoryPut = new CategoryPut(category);
        this.categoryService.update(categoryPut).subscribe((response: any) =>
           {
             this.spinner.hide();
             this.toastr.success(response.message, this.action);
           }, error => {

             this.spinner.hide();
          });
      }

      saveChanges(category: any){
        if (this.category.id === undefined || this.category.id === '')
           this.insertCategory(category);
        else
           this.updateCategory(category);
    }
}
