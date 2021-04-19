import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Employee } from '../shared/employee.model';
import { EmployeeService } from '../shared/employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styles: []
})
export class EmployeeDetailsComponent implements OnInit {

  constructor(public service : EmployeeService,  private toastr: ToastrService) { }
  
  ngOnInit() {
    this.service.getAllEmployees();
  }

  //this method is used to populate the form based on the selected employee id
  PopulateForm(selectedEmployee: Employee){
   this.service.getEmployeeInfo(selectedEmployee.employeeId).subscribe(
    res => { 
      this.service.formData = res as Employee;
    },
    err => {
      console.log(err);
    }
  );
  }
  AddNewRecord(){
    location.reload();
    }
  //this method is used to delete the record from database based on the selected employee id
  DeleteEmployeeRecord(id){
    this.service.deleteEmployeeInfo(id).subscribe(
      res => { 
        this.service.getAllEmployees();
        this.toastr.success('successfully deleted the employee information','Employee Register')

      },
      err => {console.log(err);
        this.toastr.error(err);
      }
    );
  }
  

}
