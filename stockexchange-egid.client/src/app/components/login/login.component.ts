// login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: { username: any, password: any } = { username: "", password :"" };
  constructor(private router: Router, private loginService: LoginService) { }

  login(): void {
    this.loginService.login(this.loginForm).subscribe(
      (response) => {
        // token comes in response
        const token = response;
        this.loginService.storeToken(token);
        this.router.navigate(['/stocks']); // Redirect after successful login
      },
      (error) => {
        console.error('Login failed:', error);
        // handle login failure
      }
    );
  }
}
