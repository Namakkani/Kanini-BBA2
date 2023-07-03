import { Component, OnInit } from '@angular/core';
import { SignupService } from '../service/signup.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit{

  constructor(private service:SignupService, private router:Router){}

  ngOnInit(): void {
    this.getDoctors();
   }

   public doctors: any;
  
  getDoctors()
  {
    this.service.getDoctorData().subscribe(result=>{
      this.doctors = result;
    })    
  }

  LogOut()
  {
    this.router.navigateByUrl('homepage');
  }
}
