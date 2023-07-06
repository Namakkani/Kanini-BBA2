import { Component, OnInit } from '@angular/core';
import { SignupService } from '../service/signup.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit{

  constructor(private service:SignupService, private router:Router){}

  public doctors: any;
  public rowCount: number;
  public doctors_available: any;

  ngOnInit(): void {
   this.getDoctorRequest();
   this.getDoctors();
  }

  getDoctorRequest()
  {
    this.service.getDoctorRequest().subscribe(result=>{
      this.doctors = result;
      this.rowCount = this.doctors.length;
      
    })
    
  }

  acceptDoctorRequest(doctor:any)
  {
    
    doctor.password="";
    doctor.hashKey="";
    console.log(doctor);
    this.service.approveStaff(doctor).subscribe(data => { console.log("Staff Register") ;
        setTimeout(() => {
          this.router.navigate(['login']);
        }, 3000);
      },
        err => {
          console.log(err)
        });
         alert("request Approved");

         this.service.DeleteProduct(doctor.id).subscribe(
          
            
        )
 }

 deleteDoctorRequest(doctor:any)
 {
  this.service.DeleteProduct(doctor.id).subscribe(
    (result) => { alert("Doctor Request Deleted");},
    (error)  => {
      alert("Error");
      }
  )
  this.router.navigate(['login']);
 }

 DeleteDoctorUsers(doctor:any)
 {
    this.service.DeleteDoctorFromUsers(doctor.id).subscribe(
      (result) => {alert ("Doctor Access Revoked");},
      (error) =>
      {
        alert("Error");
      }
    )
    this.router.navigate(['login']);
 }

 LogOut()
  {
    this.router.navigateByUrl('homepage');
  }

  getDoctors()
  {
    this.service.getDoctorData().subscribe(result2=>{
      this.doctors_available = result2;
      console.log(this.doctors_available);
    }) 
  }
}
