import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FollowModel } from '../Models/FollowModel';

@Injectable({
  providedIn: 'root'
})
export class FollowersService {
  _User_Url = 'https://localhost:44364/api/user';
  _Tweet_Url = 'https://localhost:44364/api/tweet';
  _Play_Url = 'https://localhost:44364/api/playground';
  constructor(private http:HttpClient) { }


  Follow(followModel:FollowModel)
  {
    return this.http.post<FollowModel>(`${this._User_Url}/follow`,followModel)
  }
  UnFollow(followModel:FollowModel)
  {
    return this.http.post<FollowModel>(`${this._User_Url}/unfollow`,followModel)
  }

  // }
  // TotalFollowers(id:string)
  // {
  //   return this.http.get<any>(`${this._User_Url}/followerCount/${id}`);
  // }
  // TotalFollowing(id:string)
  // {
  //   return this.http.get<any>(`${this._User_Url}/followingCount/${id}`);
  // }

  allFollowers(id:string)
  {
    return this.http.get<any>(`${this._User_Url}/allFollowers/${id}`);
  }
  
}
