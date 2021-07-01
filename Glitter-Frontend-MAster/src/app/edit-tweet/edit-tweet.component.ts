import { Component, OnInit } from '@angular/core';
import { EditService } from './edit.service';
import { EditTweetModel } from './EditTweet';
import { error } from 'protractor';

@Component({
  selector: 'app-edit-tweet',
  templateUrl: './edit-tweet.component.html',
  styleUrls: ['./edit-tweet.component.css']
})
export class EditTweetComponent implements OnInit {

  TweetID;
  UserID;
  Message;
  constructor(private _editService:EditService) { }

  editModel:EditTweetModel;
  ngOnInit(): void {
    this.TweetID = localStorage.getItem('TweetID');
    this._editService.GetTweet(this.TweetID)
      .subscribe(data=>{
        this.UserID = sessionStorage.getItem("UserID"),
        this.Message = data.Message,
        this.TweetID = data.TweetID})
        this.editModel= new EditTweetModel(this.TweetID,this.UserID,this.Message);    
  }
  onEdit(Message)
  {
    this.TweetID = localStorage.getItem("TweetID");
    this.UserID = sessionStorage.getItem("UserID");
    const editTweetModel = new EditTweetModel(this.TweetID,this.UserID,Message.Message);

    this._editService.EditTweet(editTweetModel)
        .subscribe(data=>{
          console.log('Success!',data)
          console.log(Message.Message)},
          error=>console.log("Error",error)
        )

    
  }

  



}
