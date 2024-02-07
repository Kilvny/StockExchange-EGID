import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private signalRService: SignalRService) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addEventListener('ReceivedPrice', (symbol, price, timestamp) => {
      console.log('Received data:', { symbol, price, timestamp });
      // Handle the received data as needed
    });
  }
}
