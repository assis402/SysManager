import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Guid } from "guid-typescript";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { UnityService } from "src/app/services/unity-service";
import { UnityView } from "../models/unity-view";
import { UnityPost } from "../models/unity-post";
import { UnityPut } from "../models/unity-put";

@Component({
    selector:'app-unity-maintenance',
    templateUrl:'./unity-maintenance.component.html'
})

export class UnityMaintenanceComponent implements OnInit {

@Input() bodyDetail = '';
public modalVisible = false;
unity = new UnityView();
action = 'Inserir';

@Input() id: any = '';
idDefault = Guid.EMPTY;
@Input() urlReturn = '/unity/unity';

    constructor(
                private route: ActivatedRoute,
                private router: Router,
                private formBuilder: FormBuilder,
                private activedRouter: ActivatedRoute,
                private unityService: UnityService,
                private spinner: NgxSpinnerService,
                private toastr: ToastrService
               ){}

    formUnity = new FormGroup({
                id: this.formBuilder.control(this.unity.id),
                name: this.formBuilder.control(this.unity.name),
                active: this.formBuilder.control(this.unity.active),
               });

    ngOnInit(){
        this.id = this.activedRouter.snapshot.params['id'];
        if (this.id != undefined && this.id != this.idDefault && this.id != null) {
            this.action = 'Alterar';
            this.getById(this.id);
          } else {
            this.action = 'Inserir';
            this.unity = new UnityView();
            this.formUnity.patchValue(this.unity);
          }
    }

    getById(id: string) {
        this.spinner.show();
        this.unityService.getByID(id).subscribe(view => {
          this.unity = view;
          this.updateForm(this.unity);
          this.spinner.hide();
        }, error  => {
          this.toastr.error(this.defaultMessage(error), this.action); 
          this.spinner.hide();
        });
      } 
      
      updateForm(unity: UnityView){
        this.formUnity = new FormGroup({
          id: this.formBuilder.control(unity.id),
          name: this.formBuilder.control(unity.name),
          active: this.formBuilder.control(unity.active),});  
      }      

    confirmdelete(){
      if(this.unity.id != undefined && this.unity.id != '')
      {
          this.spinner.show();
          this.unityService.delete(this.unity.id).subscribe((response: any) => {
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
      this.bodyDetail = 'Deseja realmente Excluir o registro ('+this.unity.name+')';
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

      insertUnity(unity: UnityView) {
        this.spinner.show();
        const unityPost = new UnityPost(unity);
        this.unityService.insert(unityPost).subscribe((response: any) =>
           {
            this.spinner.hide();
            this.toastr.success(response.message, this.action);
            this.redirect(this.urlReturn);        
           }, error => {
            this.toastr.error(this.defaultMessage(error), this.action); 
            this.spinner.hide();
        });
      }    
      
      updateUnity(unity: UnityView) {
        this.spinner.show();
        const unityPut = new UnityPut(unity);
        this.unityService.update(unityPut).subscribe((response: any) => 
           {
             this.spinner.hide();
             this.toastr.success(response.message, this.action);
           }, error => {
             this.toastr.error(this.defaultMessage(error), this.action); 
             this.spinner.hide();
          });
      }
          
      saveChanges(unity: any){
        if (this.unity.id === undefined || this.unity.id === '') 
           this.insertUnity(unity);
        else 
           this.updateUnity(unity);
    }
}