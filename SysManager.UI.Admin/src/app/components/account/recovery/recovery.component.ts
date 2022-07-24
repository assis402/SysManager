import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AccountService } from "../../../services/account-service"
import { AccountPutRequest } from "../models/account-put-request";
import { AccountView } from "../models/account-view";

@Component({
  selector: 'app-recovery',
  templateUrl: './recovery.component.html'
})
export class RecoveryComponent implements OnInit {

  returnUrl: string = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountService : AccountService
  ) {}

  ngOnInit(){
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/'
  }

  recovery(){
    this.hideMessage();
    let iUserName = (<HTMLInputElement>document.getElementById('username')).value;
    let iEmail = (<HTMLInputElement>document.getElementById('email')).value;
    let iNewPassword = (<HTMLInputElement>document.getElementById('password')).value;
    let iNewPasswordConfirm = (<HTMLInputElement>document.getElementById('passwordConfirm')).value;

    if (iUserName == '' || iUserName == undefined){
      this.showMessage("Informe um usuário");
      return;
    }

    if (iEmail == '' || iEmail == undefined){
      this.showMessage("Informe um email");
      return;
    }

    if (iNewPassword == '' || iNewPassword == undefined){
      this.showMessage("Informe sua senha");
      return;
    }

    if (iNewPassword != iNewPasswordConfirm){
      this.showMessage("Verifique se as senhas conferem...");
      return;
    }

    const account = new AccountPutRequest(iUserName, iEmail, iNewPassword);

    this.showLoading();
    this.accountService.recoveryAccount(account).subscribe((response: any) => {
      console.log('sucesso');
      console.log(`${JSON.stringify(response)}`);
      this.hideLoading();
      this.router.navigateByUrl('/login');
    }, error => {
      console.log(`${JSON.stringify(error)}`);
      console.log('erro');
      this.hideLoading();
      this.showMessage("Erro ao se comunicar com o servidor");
    })
  }

  showMessage(value:string){
    const colErrors = document.getElementById('colerror')!;
    var idvAlert = (<HTMLDivElement>document.getElementById('dvAlert'));
    idvAlert.innerHTML = value;
    colErrors.style.display='';
   }

  hideMessage(){
       const colErrors = document.getElementById('colerror')!;
       var idvAlert = (<HTMLDivElement>document.getElementById('dvAlert'));
       idvAlert.innerHTML = '';
       colErrors.style.display='none';
   }

   showLoading(){
    const loading = document.getElementById('loading')!;
    loading.style.display='';
   }

  hideLoading(){
       const loading = document.getElementById('loading')!;
       loading.style.display='none';
  }
}
