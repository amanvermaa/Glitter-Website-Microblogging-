import { Component, OnInit } from '@angular/core';
import { SearchService } from './search.service';
import { error } from 'protractor';
import { FollowModel } from '../Models/FollowModel';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public AllUsers:Array<Object>;
  text;
  id;
  followModel:FollowModel;
  constructor(private _service : SearchService) { }

  ngOnInit(): void {
    this.text = localStorage.getItem('search');
    this._service.searchUser(this.text)
    .subscribe((data:Array<Object>)=>
    { 
      this.AllUsers = data,
      console.log("Data Received")
      console.log(data),
    
error => console.log('Error',error)})


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
