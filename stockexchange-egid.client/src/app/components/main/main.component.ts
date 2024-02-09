import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { SignalRService } from '../../services/signalr.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  stockData: any[] = [
    {
      "symbol": "AAPL",
      "price": 0,
      "timestamp": "Loading...",
      previousPrice: undefined
    },
    {
      "symbol": "GOOGL",
      "price": 0,
      "timestamp": "Loading...",
      previousPrice: undefined
    },
    {
      "symbol": "MSFT",
      "price": 0,
      "timestamp": "Loading...",
      previousPrice: undefined
    },
    {
      "symbol": "AMZN",
      "price": 0,
      "timestamp": "Loading...",
      previousPrice: undefined
    },
    {
      "symbol": "TSLA",
      "price": 0,
      "timestamp": "Loading...",
      previousPrice: undefined
    }
  ];
  constructor(
    private signalRService: SignalRService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addEventListener('ReceivedPrice', (symbol, price, timestamp) => {
      console.log('Received data:', { symbol, price, timestamp });

      // Find the stock object by symbol
      const stockToUpdate = this.stockData.find(stock => stock.symbol === symbol);

      // If the stock is found, update its previousPrice and price
      if (stockToUpdate) {
        // Store the current price as the previousPrice if it's not the first update
        if (stockToUpdate.price !== 0) {
          stockToUpdate.previousPrice = stockToUpdate.price;
        }
        // Update current price and timestamp
        stockToUpdate.price = price;
        stockToUpdate.timestamp = timestamp;

        // Manually trigger change detection
        this.cdr.detectChanges();
      }
    });
  }
}
