import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-stock-table',
  templateUrl: './stock-table.component.html',
  styleUrls: ['./stock-table.component.css']
})
export class StockTableComponent {
  @Input() stocks: any[] = [];

  displayedColumns: string[] = ['symbol', 'price', 'timestamp', 'actions'];

  buyStock(stock: any) {
    // Implement your buy logic here
    console.log('Buy stock:', stock);
  }

  sellStock(stock: any) {
    // Implement your sell logic here
    console.log('Sell stock:', stock);
  }
}

