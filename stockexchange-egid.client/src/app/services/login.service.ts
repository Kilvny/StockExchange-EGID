import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(credentials: any): Observable<any> {
    return this.http.post<any>('https://localhost:7009/api/Auth/Login', credentials);
  }

  storeToken(token: string): void {
    localStorage.setItem('token', token);
  }
}
