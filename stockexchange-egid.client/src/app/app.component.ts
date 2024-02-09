import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { LoginService } from './services/login.service';
import { SignalRService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _authService: LoginService) { }

  ngOnInit() {
  }

  logout() {
    //this._authService.logout();
  }
}
