import { Component, OnInit, ViewChild } from '@angular/core';
import { Budget } from '../models/budget.model';
import { BudgetService } from '../services/budget.service';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
  budget: Budget;
  constructor(private budgetService:BudgetService, 
    private accountService: AccountService,
    private router:Router) {
    this.budget = new Budget();
  }

  ngOnInit() {
    if (this.accountService.user === undefined) {
      this.router.navigate(["/"]);
    }
  }

  cancel(){
    this.router.navigate(["home"]);
  }
  save(event){
    event.preventDefault();
    this.budgetService.save(this.accountService.user.person_id, this.budget,this.complete)
    .subscribe((data)=>{
        this.budget = new Budget();
      },(error)=>{
        console.error(error);
    },this.complete);
  }

  calculate(){
    this.budgetService.calculate(this.budget)
    .subscribe((data:any)=>{
      console.log(data);
      this.budget.desTotal = data.design_total;
      this.budget.devTotal = data.dev_total;
      this.budget.smTotal = data.sm_total;
      this.budget.poTotal = data.po_total;
      this.budget.durTotal = data.dur_total;
      this.budget.total = data.total;
    },(error)=>{});
  }

  complete(){
  }
}
