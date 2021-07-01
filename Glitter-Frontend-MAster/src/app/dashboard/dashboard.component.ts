import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { CreateTweetModel } from '../Models/CreateTweetModel';
import { DashboardService } from './dashboard.service';
import { LikeDislikeModel } from '../Models/LikeDislike';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public AllTweets :Array<Object>;
  public Name :string;
  id:string;
  
  constructor(private _dashService:DashboardService,private _router:Router,private _apiService:ApiService) { }

  ngOnInit(): void{

    this.Name = sessionStorage.getItem('Name');
    this.id =sessionStorage.getItem('UserID');
    this._dashService.allTweetsForUser(this.id)
      .subscribe((data:Array<Object>)=>
                        { 
                          this.AllTweets = data,
                          console.log("Data Received")
                          console.log(data),
                        
                error => console.log('Error',error)})


  }

  onCreate(formData)
  {
    this.id = sessionStorage.getItem('UserID');

    const createTweet = new CreateTweetModel(this.id,formData);
    this._apiService.createTweet(createTweet)
        .subscribe(
            data=> console.log('Success!',data),
            error=> console.log('Error!',error))
  }

  refresh()
  {
    this._router.navigate(['/playground/dashboard/',this.id]);
  }
  like(tweetID,userID)
  {
    // localStorage.setItem('likeUser',tweetID);
    // localStorage.setItem('likeTweet',userID);
    // this._router.navigate(['/like/']);
    const Model = new LikeDislikeModel(tweetID,userID)
    this._dashService.like(Model)
      .subscribe(data=>
        console.log('Success',Model),
        error=>console.log('Error',error))


  }
  dislike(tweetID,userID)
  {
    const Model = new LikeDislikeModel(tweetID,userID)
    this._dashService.dislike(Model)
      .subscribe(data=>
        console.log('Success',Model),
        error=>console.log('Error',error))
    
  }

  

  
}
