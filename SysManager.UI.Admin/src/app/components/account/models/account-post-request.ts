export class AccountPostRequest {
  userName: string = '';
  email: string = '';
  password: string = '';
  passwordConfirme: string = '';

  constructor(userName: string, email: string, password: string, passwordConfirme: string) {
    this.userName = userName;
    this.email = email;
    this.password = password;
    this.passwordConfirme = passwordConfirme;
  }
}
