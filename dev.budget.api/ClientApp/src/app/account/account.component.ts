import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { Account } from '../models/account.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  router: Router;
  account: Account;
  constructor(router: Router, private service: AccountService) { 
    this.router = router;
    this.account = new Account();
  }

  ngOnInit() {
  }

  signin(){
    console.log("back to login");
    this.router.navigate(['login']);

  }

  signup(event){
    this.account.user.username = this.account.email;
    this.service.signup(this.account,this.complete)
    .subscribe({
      next:null,
      error:null,
      complete: this.complete
    });
  }

  complete(){
    this.router.navigate(['']);
  }
}
