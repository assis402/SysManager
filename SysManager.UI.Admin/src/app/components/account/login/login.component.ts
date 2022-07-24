import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AccountService } from "../../../services/account-service"
import { AccountLoginView } from "../models/account-login-view";
import { AccountView } from "../models/account-view";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  returnUrl: string = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountService : AccountService
  ) {}

  ngOnInit(){
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/'
  }

  login(){
    this.hideMessage();
    let iEmail = (<HTMLInputElement>document.getElementById('email')).value;
    let iPassword = (<HTMLInputElement>document.getElementById('password')).value;

    if (iEmail == '' || iEmail == undefined){
      this.showMessage("Informe um email");
      return;
    }

   if (iPassword == '' || iPassword == undefined){
      this.showMessage("Informe sua senha");
      return;
    }

    const account = new AccountLoginView(iEmail, iPassword);

    this.showLoading();
    this.accountService.login(account).subscribe((response: any) => {
      console.log('sucesso');
      console.log(`${JSON.stringify(response)}`);
      this.hideLoading();
      this.router.navigateByUrl('/');
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
