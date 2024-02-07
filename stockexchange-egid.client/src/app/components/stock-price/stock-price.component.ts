import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-stock-price',
  templateUrl: './stock-price.component.html',
  styleUrls: ['./stock-price.component.css']
})
export class StockPriceComponent implements OnInit {
  stockPrice: string = 'Waiting for price...';

  constructor() { }

  ngOnInit(): void {

    try {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:7001/stockhub')
      .build();

    connection.on('ReceivePrice', (stock: string, price: number) => {
      // Update the stock price
      this.stockPrice = `${stock}: $${price}`;

      // Log the price to the console
      console.log(`Received new price for ${stock}: $${price}`);
    });

    connection.start()
      .then(() => console.log('SignalR connection established'))
      .catch(err => console.error(err.toString()));
    } catch (e) {
      console.log("and error occured : ", e);
    }
  }
}
