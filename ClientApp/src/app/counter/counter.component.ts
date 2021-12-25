import { Component, Inject } from '@angular/core';
import { interval, Subscription } from 'rxjs';

import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  mySubscription: Subscription;
  public forecasts: StockForecast;
  public bidValue = "9";
  public baseurl = "";
  public currentCount = 10;
  public httpval: HttpClient;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpval = http;
    this.baseurl = baseUrl;
    http.get<StockForecast>(baseUrl + 'StockForecast').subscribe(result => {
      this.forecasts = result;
      this.bidValue = result.bidValue;
      //this.forecasts.Bid = "100";
    }, error => console.error(error));
  }


  ngOnInit() {

    



  }


  public incrementCounter() {

    this.mySubscription = interval(2000).subscribe((x => {
      this.counter();
    }));



  }
  public counter() {
    this.httpval.get<StockForecast>(this.baseurl + 'StockForecast').subscribe(result => {
      this.forecasts = result;
      this.bidValue = result.bidValue;
    }, error => console.error(error));
    this.currentCount++;

  }
 
}


interface StockForecast {
  bidValue: string;
  silverbidValue: string;
}
