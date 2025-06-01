import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginObj={
    username: '',
    password: ''  
  };//but should not use any

  http = inject(HttpClient);
  router = inject(Router);
  onLogin() {
    
    this.http.post('http://localhost:5197/api/EmployeeManagement/login', this.loginObj).subscribe((res:any)=>{
      
      if(res.result){
        localStorage.setItem('employeeApp', JSON.stringify(res.data));
        this.router.navigateByUrl('dashboard');
      }else{
        alert(res.message)
      }
    });
    
  }
}
