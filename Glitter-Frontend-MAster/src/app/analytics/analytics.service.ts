import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AnalyticsService {

  _User_Url = 'https://localhost:44364/api/user';
  _Tweet_Url = 'https://localhost:44364/api/tweet';
  _Play_Url = 'https://localhost:44364/api/playground';
  _Analytics_Url = 'https://localhost:44364/api/analytics';
  constructor(private _http:HttpClient) { }

  trendingHash()
  {
    return this._http.get<string>(`${this._Analytics_Url}/trendingHashtag`)
  }
}
