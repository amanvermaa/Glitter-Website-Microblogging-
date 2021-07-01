import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { LoginUserModel } from '../Models/LoginUserModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  errorList: string[] = [];
  invalidLoginCredentials = false;
  showValidationMessages: Boolean;
  constructor(private _apiService:ApiService,private _router:Router) { }
  x;
  
  ngOnInit(): void {

  }
  onLogin(formData)
  {
    
    this._apiService.login(formData.Email,formData.Password)
        .subscribe(
          data=> {
            console.log('Success!',data),
            this.x = data;
            sessionStorage.setItem('UserID',this.x.UserID);
            sessionStorage.setItem("Name",this.x.Name);
            sessionStorage.setItem('Username',this.x.Email);
            this.invalidLoginCredentials = false;
            console.log("This is the session : ",sessionStorage.getItem('UserID'));
            this._router.navigate(['/playground/dashboard',sessionStorage.getItem('UserID')]);
          },            
          error => console.error('Error!',error)
        )
  }
  onRegister()
  {
    this._router.navigate(['/register']);
  }


}
