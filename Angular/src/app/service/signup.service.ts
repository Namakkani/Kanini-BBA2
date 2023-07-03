import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { registerModel } from "../register/model/register.model";
import { UserDTOModel } from "../register/model/userDTO.model";
import {Injectable} from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs'

@Injectable()
export class SignupService{

    staffMembers: any[] = [];

    addStaffMember(member: any) {
        this.staffMembers.push(member);
      }

      getStaffMembers() {
        return this.staffMembers;
      }

    private register: registerModel[] = [];

    constructor(private httpClient:HttpClient)
    {

    }

    addUser(register: registerModel) {
        this.register.push(register);
        console.log(register);
      }
    
      getUsers(): registerModel[] {
        return this.register;
      }

    signup(register:registerModel){
        console.log("register in service");
        console.log(register);
        return this.httpClient.post("https://localhost:7192/api/User/Register",register);
    }

    signupStaff(register:registerModel)
    {
        console.log(register);
        console.log("Registered ");

        return this.httpClient.post("https://localhost:7192/api/Staff",register);
    }

    approveStaff(register:registerModel)
    {
        console.log(register);
        console.log("Staff approved");
        return this.httpClient.post("https://localhost:7192/api/User/Register",register);
    }

    userLogin(userDTO:UserDTOModel){
        return this.httpClient.post("https://localhost:7192/api/User/Login",userDTO);
    }

    getDoctorRequest()
    {
        return this.httpClient.get(`https://localhost:7192/api/Staff`);
    }

    public DeleteProduct(id:any)
    {
        console.log(id);
      return this.httpClient.delete(`https://localhost:7192/api/Staff/` + id).pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMessage = '';
          if (error.error instanceof ErrorEvent) {
            // Client-side error occurred
            errorMessage = error.error.message;
          } else {
            // Server-side error occurred
            errorMessage =  error.error;
          }
          return throwError(errorMessage);
        })
      );
    }

    public DeleteDoctorFromUsers(id:any)
    {
      return this.httpClient.delete(`https://localhost:7192/api/User/` + id).pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMessage = '';
          if (error.error instanceof ErrorEvent) {
            // Client-side error occurred
            errorMessage = error.error.message;
          } else {
            // Server-side error occurred
            errorMessage =  error.error;
          }
          return throwError(errorMessage);
        })
      );
    }

    getDoctorData()
    {
      return this.httpClient.get(`https://localhost:7192/api/User`);
    }
}