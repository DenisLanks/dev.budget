import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { IUser } from "../interfaces/IUser";

@Injectable({
    providedIn:"root"
})
export class AccountService {
    baseurl :string;
    constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl;
    }

    signin(username: string, password: string): Observable<IUser>{
        //alert(this.baseurl);
        //return this.http.get<IUser>(`${this.baseurl}account`);
        return this.http.post<IUser>( `${this.baseurl}api/account/login`,{
            username,
            password
        }).pipe(catchError(this.handlerError));
    }

    signup(payload: any, callback:Function){console.log(payload);
        return this.http.post( `${this.baseurl}api/account`,payload)
        .pipe(tap(result => callback(result,null)),catchError(this.handlerError));
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