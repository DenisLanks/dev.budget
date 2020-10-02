import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { tap, catchError } from "rxjs/operators";
import { throwError } from "rxjs";
import { Budget } from "../models/budget.model";

@Injectable({
    providedIn:"root"
})
export class BudgetService {
    baseurl: string;

    constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl;
    }

    save(payload: Budget, callback:Function){
        return this.http.post( `${this.baseurl}api/budget/1`,payload)
        .pipe(tap(result => callback(result,null)),catchError(this.handlerError));
    }

    getBudgets(id:number){
        return this.http.get<any>( `${this.baseurl}api/budget/${id}`)
        .pipe(tap(result => {console.log(result)}),catchError(this.handlerError));
    }
    
    handlerError(err: HttpErrorResponse) {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
            errorMessage = `Ocorreu um erro: ${err.error.message}`;
        } else {
            errorMessage = `O servidor retornou o código: ${err.status}, a mensagem do erro: ${err.message}`
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
   
}