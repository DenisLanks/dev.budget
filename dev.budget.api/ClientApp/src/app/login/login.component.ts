import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  accountService: AccountService;
  
  constructor(service: AccountService, private router: Router) { 
    this.accountService = service;
  }

  ngOnInit() {
  }

  signin(event){
    event.preventDefault();
    if (!this.validate()) {
      alert("Informe seus dados de acesso.");
      return;
    }
    this.accountService.signin(this.username, this.password)
    .subscribe({
      next: data=>{
        if (data.Code == 200 || data.Code == "200") {
          this.router.navigate(["home"]);
        }else{
          alert(data.Message);
        }
      },
      error: err=>console.error(err)
    });

  }

  validate(): boolean{
      if (this.username === undefined || this.username.trim() === '')
          return false;
      
      if (this.password === undefined || this.password.trim() === '')
          return false;

      return true;
  }
}
