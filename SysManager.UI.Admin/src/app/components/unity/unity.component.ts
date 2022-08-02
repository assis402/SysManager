import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { PagerService } from "src/app/services/page-service";
import { UnityService } from "src/app/services/unity-service";
import {UnityFilter} from './models/unity-filter';

@Component({
    selector:'app-unity',
    templateUrl:'./unity.component.html'
})

export class UnityComponent implements OnInit {

    @Input() bodyDetailTodelete = '';
    public openCloseModal =false;

    public modalVisible = false;
    public pager: any={};
    public idToDelete = '';
    pageSize = 10;
    firstPage = 1;
    pagedItems: any[]=[];

    constructor(
                private route: ActivatedRoute,
                private router: Router,
                private formBuilder: FormBuilder,
                private unityService:UnityService,
                private spinner: NgxSpinnerService,
                private pagerService: PagerService,
                private toastr: ToastrService

               ){}

    formFilter = new FormGroup({
                                 name: this.formBuilder.control(''),
                                 active: this.formBuilder.control('todos'),
                                 pageSize: this.formBuilder.control('10')
                                });

    ngOnInit(){
    }


    confirmdelete(){
        if(this.idToDelete != undefined && this.idToDelete != '')
        {
            this.spinner.show();
            this.unityService.delete(this.idToDelete).subscribe((response: any) => {
                this.toastr.success(response.message,'Unidade de medida');
                this.filterView(this.formFilter.value,1);
                this.spinner.hide();
                },error => {
                    this.spinner.hide();
                    this.toastr.error(error,'Unidade de medida');
                });
        }
        this.idToDelete = '';
        this.modalVisible = false;
    }
    
    canceldelete(){
      this.modalVisible = false;
    }

    handleChangeModal(event:any){
    }

    prepareDelete(id:string, name:string){
        this.idToDelete = id;
        this.bodyDetailTodelete = 'Deseja realmente Excluir o registro ('+name+')';
        this.modalVisible = !this.modalVisible;
    }

    redirectUpdate(url:string, id:string){
        this.router.navigate([url,id])
    }

    redirectTo(url:string){
    this.router.navigateByUrl(url);
    }

    filterView(filter:UnityFilter, page:number){
        this.spinner.show();
        let _filter = new UnityFilter(filter.name, filter.active, page, filter.pageSize);
        this.unityService.getByFilter(_filter).subscribe(view => {
        this.pagedItems = view.items;
        this.pager = this.pagerService.getPager(view._total,page, view._pageSize);
        this.spinner.hide();
        },error => {
            this.spinner.hide();
        });
    }
}