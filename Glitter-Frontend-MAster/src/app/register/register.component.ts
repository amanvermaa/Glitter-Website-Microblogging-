import { Component, OnInit } from '@angular/core';
import { RegisterUserModel } from '../Models/RegisterUserModel';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  countries =['India','USA','China','France','Germany','Iraq','Italy','Kuwait','Malaysia','Maldives'];
  ImageUrl : string = "/assets/image/download.png"
  fileToUpload:File = null;
  constructor(private _apiservice : ApiService,private _router:Router) { }

  ngOnInit(): void {
  }
  handleFileInput(file:FileList)
  {
    this.fileToUpload = file.item(0);
    var reader = new FileReader();
    reader.onload = (event: any)=>{
      this.ImageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
    
    
  
  }

  onSubmit(formData)
  {
    const registerModel = new RegisterUserModel(formData.Name,formData.Email,formData.Password,formData.ContactNo,formData.Country,formData.Image);
    
    this._apiservice.register(registerModel)
        .subscribe(
          data=> {console.log('Success!',data);
                  registerModel.Name = null;
                  registerModel.Email= null;
                  registerModel.Password = null;
                  registerModel.ContactNo = null;
                  registerModel.Country = null;
                  this.ImageUrl = "/assets/image/download.png"
                  this._router.navigate(['login'])
         },
          error => console.error('Error!',error)          
        )
        

  }

  onLogin()
  {
    this._router.navigate(['/login']);
  }

}
