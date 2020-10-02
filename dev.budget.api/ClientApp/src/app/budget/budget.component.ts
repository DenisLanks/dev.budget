import { Component, OnInit } from '@angular/core';
import { Budget } from '../models/budget.model';
import { BudgetService } from '../services/budget.service';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
  budget: Budget;

  constructor(private budgetService:BudgetService) {
    this.budget = new Budget();
  }

  ngOnInit() {
  }

  save(event){
    event.preventDefault();
    this.budgetService.save(this.budget,this.complete)
    .subscribe((data)=>{
        console.log(data);
      },(error)=>{
        console.error(error);
    },this.complete);
  }

  complete(){
      console.log("Budget salvo.");
  }
}
