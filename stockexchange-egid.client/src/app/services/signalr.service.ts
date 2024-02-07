import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private connection: signalR.HubConnection;

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7009/stockhub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
        accessTokenFactory: () => {
          // Add your access token factory logic here
          return '';
        }
      })
      .build();
  }

  startConnection() {
    this.connection.start().then(() => {
      console.log('SignalR connection established');
    }).catch(err => {
      console.error('SignalR connection error: ' + err);
    });
  }

  addEventListener(eventName: string, handler: (...args: any[]) => void) {
    this.connection.on(eventName, handler);
  }
}
