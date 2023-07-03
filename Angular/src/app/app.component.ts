import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {LoginComponent} from './login/login.component'
import { isEmpty } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  title = 'InternManagementApp';
  roleStatus:boolean=false
  role:string=""
  
  username:string = localStorage.getItem("UserID")
  
  flag:boolean = false;

  
  constructor( private router : Router   ){

    //  this.login.loggedInUser = null;
    //this.router.navigate(['/', 'login']);
     this.router.navigate(['/', 'homepage']);

    this.role = localStorage.getItem("role");
    if (this.role == "Admin")
    {
      this.flag=true;
    }
  }

  logout(){
    localStorage.setItem("role","");
    localStorage.setItem("login","")
    
    this.router.navigateByUrl('login');
  }
  
  // check()
  // {
    //   console.log('chk');
    //   this.isLoggedIn();
    //   console.log(this.isLoggedIn());
    // }
    
  login : LoginComponent
  isLoggedIn():boolean
  {
    // if (localStorage.length !== null)
    // {
    //   return false;
    // }
    // else  { 
    // return true;
    // }
    // console.log(this.login.loggedInUser)
    this.username = localStorage.getItem("UserID");
    console.log(localStorage.getItem("role"));
    return localStorage.getItem("token") !== null && this.router.url !== '/login';
    
  }
  
  

  // checkLoggedInUser()
  // {
  //   this.isLoggedIn();
  //   console.log(this.isLoggedIn());
  // }
  
}
