import { Component } from '@angular/core';
import { BudgetService } from '../services/budget.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    /**
     *
     */
    budgets: Array<any>
    constructor(private service: BudgetService) {
            
    }

    ngOnInit() {
      this.service.getBudgets(1)
      .subscribe(data=>{
          console.log(data);
          if (data.Code == 200 || data.Code == "200") {
            this.budgets = data.Data;
              console.log(data.Data);
          }
      }, err=> {console.log(err);});
    }
}
