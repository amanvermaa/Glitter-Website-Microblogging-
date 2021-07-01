import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MyTweetsService {

  _User_Url = 'https://localhost:44364/api/user';
  _Tweet_Url = 'https://localhost:44364/api/tweet';
  _Play_Url = 'https://localhost:44364/api/playground';
  constructor(private http:HttpClient) { }

  getMyTweets(id:string)
  {
    return this.http.get<any>(`${this._Tweet_Url}/myTweets/${id}`);
  }

  DeleteTweet(id:string)
  {
    return this.http.delete<any>(`${this._Tweet_Url}/deleteTweet/${id}`);
  }
}

