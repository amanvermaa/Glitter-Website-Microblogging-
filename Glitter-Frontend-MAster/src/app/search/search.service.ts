import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FollowModel } from '../Models/FollowModel';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  _Play_Url = 'https://localhost:44364/api/playground';
  _User_Url = 'https://localhost:44364/api/user';

  constructor(private http:HttpClient) { }

  searchUser(text:String)
  {
    return this.http.get<any>(`${this._Play_Url}/searchUser/${text}`);
  }

  Follow(followModel:FollowModel)
  {
    return this.http.post<FollowModel>(`${this._User_Url}/follow`,followModel)
  }
  UnFollow(followModel:FollowModel)
  {
    return this.http.post<FollowModel>(`${this._User_Url}/unfollow`,followModel)
  }

}
