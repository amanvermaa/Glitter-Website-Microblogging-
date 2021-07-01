import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EditTweetModel } from './EditTweet';

@Injectable({
  providedIn: 'root'
})
export class EditService {
  play_url = 'https://localhost:44364/api/playground';
  tweet_url = 'https://localhost:44364/api/tweet';

  constructor(private http:HttpClient) { }

  GetTweet(id)
  {
    return this.http.get<EditTweetModel>(`${this.tweet_url}/getTweet/${id}`);
  }


  EditTweet(editTweet)
  {
    return this.http.put<EditTweetModel>(`${this.tweet_url}/editTweet`,editTweet);
  }
}

