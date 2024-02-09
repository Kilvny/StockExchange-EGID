import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { AppComponent } from './app.component';
import { StockTableComponent } from './components/stock-table/stock-table.component';
import { SignalRService } from './services/signalr.service';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './services/auth.guard';
import { FormsModule } from '@angular/forms';
import { MainComponent } from './components/main/main.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '', component: MainComponent, canActivate: [AuthGuard],
    children: [{path: 'stocks', component: StockTableComponent}]  },
//  { path: '', redirectTo: '/', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    StockTableComponent,
    LoginComponent,
    MainComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatTableModule,
    FormsModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true }),
    NoopAnimationsModule,

  ],
  providers: [SignalRService],
  bootstrap: [AppComponent]
})
export class AppModule { }
