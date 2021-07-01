import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAllTweets } from '../Models/AllTweets';
import { CreateTweetModel } from '../Models/CreateTweetModel';
import { LikeDislikeModel } from '../Models/LikeDislike';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  play_url = 'https://localhost:44364/api/playground';
  tweet_url = 'https://localhost:44364/api/tweet';
  id;

  constructor(private _http:HttpClient) { }

  allTweetsForUser(id:string)
  {
    return this._http.get<any>(`${this.play_url}/dashboard/${id}`) ;
  }
  like(model:LikeDislikeModel)
  {
    return this._http.post<LikeDislikeModel>(`${this.tweet_url}/like`,model);
  }
  dislike(model:LikeDislikeModel)
  {
    return this._http.post<LikeDislikeModel>(`${this.tweet_url}/dislike`,model);
  }
  
}
