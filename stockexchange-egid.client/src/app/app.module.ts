import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { StockPriceComponent } from './components/stock-price/stock-price.component';
import { SignalRService } from './services/signalr.service';

const appRoutes: Routes = [
  {
    path: 'stocks',
    component: StockPriceComponent,
    //children: [{ path: '', component: ChiledComponent }],
  },

];

@NgModule({
  declarations: [
    AppComponent,
    StockPriceComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true }),

  ],
  providers: [SignalRService],
  bootstrap: [AppComponent]
})
export class AppModule { }
