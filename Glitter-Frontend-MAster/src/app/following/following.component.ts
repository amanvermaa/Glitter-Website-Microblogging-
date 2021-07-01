import { Component, OnInit } from '@angular/core';
import { FollowingService } from './following.service';
import { RouterLink, Router } from '@angular/router';
import { error } from 'protractor';
import { FollowModel } from '../Models/FollowModel';

@Component({
  selector: 'app-following',
  templateUrl: './following.component.html',
  styleUrls: ['./following.component.css']
})
export class FollowingComponent implements OnInit {
  
  public MyFollowing :Array<Object>;
  id:string;
  followModel:FollowModel;
  constructor(private _service:FollowingService,private _route:Router) { }
  
  
 
  ngOnInit(): void {
    this.id = sessionStorage.getItem("UserID");
    this._service.allFollowing(this.id)
          .subscribe((data:Array<object>)=>
          {
            this.MyFollowing = data,
            console.log(this.MyFollowing)

          },
          error => console.log('Error!',error))
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
