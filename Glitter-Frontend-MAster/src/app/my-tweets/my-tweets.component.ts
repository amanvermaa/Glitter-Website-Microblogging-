import { Component, OnInit } from '@angular/core';
import { MyTweetsService } from './my-tweets.service';
import { Router } from '@angular/router';
import { error } from 'protractor';

@Component({
  selector: 'app-my-tweets',
  templateUrl: './my-tweets.component.html',
  styleUrls: ['./my-tweets.component.css']
})
export class MyTweetsComponent implements OnInit {

  public MyTweets :Array<Object>;
  id:string;
  constructor(private _myTweetsService:MyTweetsService,private _router:Router) { }

  ngOnInit() : void{
    this.id = sessionStorage.getItem("UserID");
    this._myTweetsService.getMyTweets(this.id)
            .subscribe((data:Array<Object>)=>
                  {
                    this.MyTweets = data,
                    console.log(this.MyTweets)
                  },
              error=>console.log('Error!',error)
            )}

    EditTweet(id1)
    {
      localStorage.setItem('TweetID',id1);
      this._router.navigate(['/editTweet']);      
    }
    delete(id1:string)
    {
       this._myTweetsService.DeleteTweet(id1)
            .subscribe(
              data=> {
                console.log(id1)
                console.log('Success',data)},
              error => console.log('Error!',error)
            );
    }
}
