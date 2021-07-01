import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterUserModel } from './Models/RegisterUserModel';
import { LoginUserModel} from './Models/LoginUserModel';
import { CreateTweetModel } from './Models/CreateTweetModel';
import { IAllTweets } from './Models/AllTweets';
import { Observable } from 'rxjs';
import { INumber } from './Models/Number';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  _User_Url = 'https://localhost:44364/api/user';
  _Tweet_Url = 'https://localhost:44364/api/tweet';
  _Play_Url = 'https://localhost:44364/api/playground';
  id;
  
  
  constructor(private _http:HttpClient) { }

  register(user:RegisterUserModel)
  {
    return this._http.post<any>(this._User_Url+"/register",user);
  }
  login(Email:string,Password:string)
  {
    const LoginModel = Object.assign({},{Email,Password})
    return this._http.post<any>(this._User_Url+'/login',LoginModel);
  }
  createTweet(tweet:CreateTweetModel)
  {
    return this._http.post<any>(`${this._Tweet_Url}/createTweet`,tweet);
  }
  
  
}
