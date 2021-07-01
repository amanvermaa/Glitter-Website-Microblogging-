import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FollowersService } from './followers.service';
import { error } from 'protractor';
import { FollowModel } from '../Models/FollowModel';

@Component({
  selector: 'app-followers',
  templateUrl: './followers.component.html',
  styleUrls: ['./followers.component.css']
})
export class FollowersComponent implements OnInit {

  public MyFollowers :Array<Object>;
  id:string;
  TotalFollowers;
  TotalFollowing;

  constructor(private _service:FollowersService ,private _route:Router) { }

  toFollow;
  followModel:FollowModel;
  ngOnInit(): void {
    this.id = sessionStorage.getItem('UserID');

    
    this._service.allFollowers(this.id)
    .subscribe((data:Array<Object>)=>
    {
      this.MyFollowers = data,
      console.log(this.MyFollowers)
    },
    error=>console.log('Error!',error))


  }



  Follow(tofollowID)
  {
    this.id = sessionStorage.getItem("UserID");

    this.followModel = new FollowModel(this.id,tofollowID);

    this._service.Follow(this.followModel)
        .subscribe(data=>
                  console.log('Success',this.followModel),
                  error=>console.log('Error!',error))

  }
  Unfollow(tounfollowID)
  {
    this.id = sessionStorage.getItem('UserID');
    this.followModel = new FollowModel(this.id,tounfollowID);

    this._service.UnFollow(this.followModel)
    .subscribe(data=>console.log('Success!',this.followModel),
                error=>console.log('Error!',tounfollowID))
    
  }

}


