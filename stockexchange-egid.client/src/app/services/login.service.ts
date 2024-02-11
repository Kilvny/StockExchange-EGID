import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  isLoggedIn: boolean = false;
  redirectUrl: string = "";
  constructor(private http: HttpClient) { }

  login(credentials: any): Observable<any> {
    let res = this.http.post<any>('https://localhost:7009/api/Auth/Login', credentials);
    if (res) {
      this.isLoggedIn = true;
    }
    else {
      this.isLoggedIn = false;
    }
    return res;
  }

  storeToken(token: string): void {
    window.localStorage.setItem('token', token);
  }

  logout() {
    this.isLoggedIn = false;
  }

}
