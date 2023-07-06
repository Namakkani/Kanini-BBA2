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
  
  title = 'Hospital Management Web ';
  roleStatus:boolean=false
  role:string=""
  
  username:string = localStorage.getItem("UserID")
  
  flag:boolean = false;

  
  constructor( private router : Router   ){

     
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
  
   
    
  login : LoginComponent
  isLoggedIn():boolean
  {
     
    this.username = localStorage.getItem("UserID");
    console.log(localStorage.getItem("role"));
    return localStorage.getItem("token") !== null && this.router.url !== '/login';
    
  }
  
}
