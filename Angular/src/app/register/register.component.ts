import { Component, OnInit, ViewChild } from '@angular/core';
import { LoggedInUserModel } from './model/loggedinuser.model';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
//import { registerModel } from './model/register.model';



// import validation from '../helper/validation';
// import { fa } from '@fortawesome/angular-fontawesome/public_api'; 


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  

  public showPasswordOnPress: boolean;
  @ViewChild('register_form') registerForm: NgForm;
  showError: boolean = false;
  registration_status = false;

  public signup_form!: FormGroup;

  register!: any;

  loggedInUser: LoggedInUserModel;

  constructor(private router: Router, private signupService: SignupService, private fb: FormBuilder) {
    // this.register = new registerModel();
    this.register =
    {
      id: "",
      email: "",
      firstName: "",
      lastName: "",
      gender: "",
      role: "",
      password: "",
      hashKey: "",
      passwordClear: "",
      qualification:"",
      specialization:"",
      yearsOfExperience:0
    }

    this.loggedInUser = new LoggedInUserModel();
  }

  ngOnInit() {
    this.signup_form = this.fb.group({
      username: ['', Validators.required]
    })
  }

  addGender(gender: any) {
    this.register.gender = gender;
  }

  onPost() {
    if (this.registerForm.valid) {
      if (this.register.role == "Doctor") {
        this.signupService.signupStaff(this.register).subscribe(data => { console.log("Staff Register") ;
        console.log(this.register);
        alert("request Submitted");
        setTimeout(() => {
          this.router.navigate(['login']);
        }, 3000);},
        err => {
          console.log(err)
        });
      }
      
      else {
        this.signupService.signup(this.register).subscribe(data => {
          console.log("register in component")
          this.loggedInUser = data as LoggedInUserModel;
          console.log(this.loggedInUser);

          localStorage.setItem("token", this.loggedInUser.token);
          localStorage.setItem("UserID", this.loggedInUser.id);
          localStorage.setItem("role", this.loggedInUser.role);
          this.registration_status = true;
          setTimeout(() => {
            this.router.navigate(['login']);
          }, 3000);
          // alert(`\t ........Registration successfull........
          //   \n your user id is : ${this.loggedInUser.id} and your password is first 4 letters of your name + your birth date and month `);

        },
          err => {
            console.log(err)
          });
      }
    }
    else {
      if (this.register.role != "Doctor")
      {
        this.showError = true; // Show the error message
      }
      
    }

    if (this.register.role == "Doctor") {
      this.signupService.signupStaff(this.register).subscribe(data => { console.log("Staff Register") ;
      console.log(this.register);
      alert("request Submitted");
      setTimeout(() => {
        this.router.navigate(['login']);
      }, 3000);},
      err => {
        console.log(err)
      });
    }

  }


  login_here() {
    this.router.navigateByUrl('login');
  }

  passwordVisible = false;

  togglePasswordVisibility(): void {
    this.passwordVisible = !this.passwordVisible;
  }

  LogOut()
  {
    this.router.navigateByUrl('homepage');
  }

}


export class registerModel {

  id: string = "";
  email: string = "";
  firstName: string = "";
  lastName: string = "";
  gender: string = "";
  role: string = "";
  password: string = "";
  hashKey: string = "";
  passwordClear: string = ""
  qualification:string="";
  specialization:string="";
  yearsOfExperience:number;

}

function registerUser() {
  throw new Error('Function not implemented.');
}
