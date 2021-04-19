export class Employee {

    employeeId: number;
    firstName: string;
    lastName: string;
    department: string;
    jobTitle: string;
    phoneExtension: string;
    salary: string;
    bonus: string;
    constructor(){
    
        //added the default values 
        this.employeeId = 0;
        this.firstName='';
        this.lastName='';
        this.department='';
        this.jobTitle='';
        this.phoneExtension='';
        this.salary='';
        this.bonus='';
        
    }

}
