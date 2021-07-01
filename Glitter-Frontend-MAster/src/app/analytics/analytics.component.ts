import { Component, OnInit } from '@angular/core';
import { AnalyticsService } from './analytics.service';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.css']
})
export class AnalyticsComponent implements OnInit {

  TrendingHash;
  TopLiked;
  constructor(private _service:AnalyticsService) { }

  ngOnInit(): void {

    this._service.trendingHash()
    .subscribe(
      data=> {this.TrendingHash = data
        console.log("The trending tag is "+this.TrendingHash)}
    )
  }

}
