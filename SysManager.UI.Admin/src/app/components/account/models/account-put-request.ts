export class AccountPutRequest {
  userName: string = '';
  email: string = '';
  newPassword: string = '';

  constructor(userName: string, email: string, newPassword: string) {
    this.userName = userName;
    this.email = email;
    this.newPassword = newPassword;
  }
}
