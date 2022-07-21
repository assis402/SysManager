import { Component, OnInit } from "@angular/core";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  constructor(){}
  ngOnInit(){
  }

  createAccount(){
    this.hideMessage();
    let iUserName = (<HTMLInputElement>document.getElementById('username')).value;
    let iEmail = (<HTMLInputElement>document.getElementById('username')).value;
    let iPassword = (<HTMLInputElement>document.getElementById('password')).value;
    let iPasswordConfirm = (<HTMLInputElement>document.getElementById('passwordConfirm')).value;

    if (iPassword !== iPasswordConfirm){
      this.showMessage('Verifique se as senhas conferem!');
    }
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
}
