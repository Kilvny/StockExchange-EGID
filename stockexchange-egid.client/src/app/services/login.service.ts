import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  isLoggedIn: boolean = false;
  redirectUrl: string = "";
  constructor(private http: HttpClient) { }
  login(credentials: any): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/text')
    let res = this.http.post<any>('https://localhost:7009/api/Auth/Login', credentials )
    if (res) {
      this.isLoggedIn = true;
      console.log(res);
      this.storeToken(res);
    }
    else {
      this.isLoggedIn = false;
    }
    return res;
  }

  storeToken(token: any): void {
    localStorage.setItem('token', token);
  }

  logout() {
    this.isLoggedIn = false;
    localStorage.removeItem('token')
  }

}
