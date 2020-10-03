import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { IUser } from "../interfaces/IUser";
import { User } from "../models/user.model";

@Injectable({
    providedIn:"root"
})
export class AccountService {
    baseurl :string;
    user: any;
    constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl;
    }

    signin(username: string, password: string): Observable<any>{
        return this.http.post<any>( `${this.baseurl}api/account/login`,{
            username,
            password
        });
    }

    signup(payload: any, callback:Function){
        return this.http.post( `${this.baseurl}api/account`,payload)
        .pipe(tap(result => callback(result)),catchError(this.handlerError));
    }

    handlerError(err: HttpErrorResponse) {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
            errorMessage = `Ocorreu um erro: ${err.error.message}`;
        } else {
            errorMessage = `O servidor retornou o código: ${err.status}, a mensagem do erro: ${err.message}`
        }
        return throwError(errorMessage);
    }
}