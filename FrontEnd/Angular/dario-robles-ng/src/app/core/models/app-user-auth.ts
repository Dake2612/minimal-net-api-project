export class AppUserAuth {
  constructor() {
    this.access_token = '';
    this.refresh_token = '';
    this.isAuthenticated = false;
  }

  public isAuthenticated: boolean;
  public access_token: string;
  public refresh_token: string;
}
