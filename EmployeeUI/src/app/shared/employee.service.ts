import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  formData: Employee = new Employee(); //create an object of Employee
  list : Employee[]; //create a list of Employee 
  
  readonly baseUrl = 'http://localhost:64884/api/employee'; //add base url
   
  // This method is used to get all the employees from the database by calling the get all method from the api
  getAllEmployees(){
    this.http.get(this.baseUrl)
    .subscribe(res =>{
      this.list = res as Employee[]; //subscribe the result and save as list of employee
    } )
  }

//this method is used to get particular employee based on employee id by calling the get method from the api
getEmployeeInfo(id){
  return this.http.get(`${this.baseUrl}/${id}`); 
}

//this method is used to insert the employee data to database by calling the create method from the api
postEmployeeInfo(){
  this.convertNumbersToString();
  return this.http.post(this.baseUrl,this.formData as Employee);
}

//this method is used to update the employee data to database by calling the update method from the api
updateEmployeeInfo(){
  this.convertNumbersToString();
  return this.http.put(this.baseUrl,this.formData as Employee);
}

//this method is used to delete particular employee based on employee id
deleteEmployeeInfo(id:number){
  return this.http.delete(`${this.baseUrl}/${id}`);
}

convertNumbersToString(){
  this.formData.phoneExtension = this.formData.phoneExtension.toString();
  this.formData.salary = this.formData.salary.toString();
  this.formData.bonus = this.formData.bonus.toString();
}





}
