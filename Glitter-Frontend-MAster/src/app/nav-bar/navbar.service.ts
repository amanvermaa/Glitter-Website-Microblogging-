import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  _User_Url = 'https://localhost:44364/api/user';
  _Tweet_Url = 'https://localhost:44364/api/tweet';
  _Play_Url = 'https://localhost:44364/api/playground';
  constructor(private _http:HttpClient) {}


  
  tweetCount(id:string)
  {
    return this._http.get<any>(`${this._Tweet_Url}/tweetCount/${id}`)
  }


  followerCount(id:string)
  {
    return this._http.get<any>(`${this._User_Url}/followerCount/${id}`);
  }
  followingCount(id:string) 
  {
    return  this._http.get<any>(`${this._User_Url}/followingCount/${id}`);   
  }


}
