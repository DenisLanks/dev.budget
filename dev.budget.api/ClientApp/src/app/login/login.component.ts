import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  accountService: AccountService;
  
  constructor(service: AccountService) { 
    this.accountService = service;
  }

  ngOnInit() {
  }

  signin(){
    console.log(`usuário: ${this.username} senha:${this.password}`);
    if (!this.validate()) {
      alert("Informe seus dados de acesso.")
    }
    this.accountService.signin(this.username, this.password)
    .subscribe({
      next: data=>console.log(data),
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
