import { Component } from '@angular/core';
import { BudgetService } from '../services/budget.service';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    /**
     *
     */
    budgets: Array<any>
    constructor(private service: BudgetService, 
      private accountServ: AccountService,
      private router:Router) {
            
    }

    ngOnInit() {
      if (this.accountServ.user === undefined) {
        this.router.navigate(["/"]);
      }else{
        console.log(this.accountServ.user.person_id);

        this.service.getBudgets(this.accountServ.user.person_id)
        .subscribe(data=>{
            console.log(data);
            if (data.Code == 200 || data.Code == "200") {
              this.budgets = data.Data;
                console.log(data.Data);
            }
        }, err=> {console.log(err);});
      }
    }
}
