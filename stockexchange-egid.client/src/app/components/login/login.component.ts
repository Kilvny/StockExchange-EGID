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
  loginForm: { email: any, password: any } = { email: "", password :"" };
  constructor(private router: Router, private loginService: LoginService) { }

  login(): void {
    this.loginService.login(this.loginForm).subscribe(
      (response) => {
        // token comes in response
        const token = response;
        this.loginService.storeToken(token);
        this.router.navigate(['/']); // Redirect after successful login
      },
      (error) => {
        if (error.status == 200) {
          localStorage.setItem("token", error.error.text)
          this.router.navigate(['/stocks']);
        }
        console.error('Login failed:', error);
        // handle login failure
      }
    );
  }
}
