import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Session } from 'protractor';
import { NavbarService } from './navbar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  totalFollowers;
  totalFollowing;
  totalTweets;
  searchText:string;
  
  public id:string;
  
  constructor(private _navService : NavbarService,private _router:Router) { }

  ngOnInit(): void {
  this.id= sessionStorage.getItem('UserID');
    this._navService.followingCount(this.id)
        .subscribe(
          (data:number)=>
          {this.totalFollowing = data}
        )

    this._navService.followerCount(this.id)
        .subscribe(
          (data:number)=>
          {this.totalFollowers = data}
        )

    this._navService.tweetCount(this.id)
          .subscribe(
            data=>{this.totalTweets = data
                  console.log("Total tweets by "+this.id+" is "+this.totalTweets)}
          )
    
   
    
  }

  allFollowers()
  {
    this._router.navigate(['/allFollowers/',this.id]);
  }
  allFollowing()
  {
    this._router.navigate(['/allFollowing/',this.id]);

  }
  myTweets()
  {
    this._router.navigate(['/myTweets/',this.id]);
  }

  dashboard()
  {
    this._router.navigate(['playground/dashboard/',this.id])
  }
  analytics()
  {
    this._router.navigate(['analytics']);
  }
  logout()
  {
    sessionStorage.clear();
    localStorage.clear();
    this._router.navigate(['login']);
  }
  

  fun(text)
  {
    this.searchText = text.text;
    localStorage.setItem('search',this.searchText);

    this._router.navigate(['searchUser/',this.searchText]);
  }

  

}
