import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/shared/employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-employee-detail-form',
  templateUrl: './employee-detail-form.component.html',
  styles: []
})
export class EmployeeDetailFormComponent implements OnInit {

  constructor(public service: EmployeeService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm){
  //check if employeeid is 0 or has value
  if (this.service.formData.employeeId == 0){
    this.insertRecord(form);
  }
  else{
    this.updateRecord(form);
  }
  }

  //this method is called when user clicks on submit and the employee id is  0, this method is used to add new record in the sql table
  insertRecord(form: NgForm){
    this.service.postEmployeeInfo().subscribe(
      res => { 
        this.resetForm(form);
        this.toastr.success('successfully added new employee information','Employee Register')
      },
      err => {console.log(err);
        this.toastr.error(err);
      }
    )
  }

  //this method is called when user clicks on submit and the employee id is not 0, this method is used to update the already existing record in the sql table
  updateRecord(form:NgForm){
    this.service.updateEmployeeInfo().subscribe(
      res => { 
        this.resetForm(form);
        this.toastr.info('successfully updated the employee information','Employee Register')
        this.service.getAllEmployees();
        

      },
      err => {console.log(err);
        this.toastr.error(err);
      }
    )
  }

  //this method is used to reset the employee form and reload the location window
  resetForm(form: NgForm){
    form: form.reset();
    this.service.formData= new Employee();
    location.reload();
  }

}
