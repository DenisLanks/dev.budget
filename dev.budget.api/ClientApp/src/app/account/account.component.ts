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
  confirmPassword: string;
  constructor(router: Router, private service: AccountService) { 
    this.router = router;
    this.account = new Account();
  }

  ngOnInit() {
  }

  signin(){
    this.router.navigate(['']);

  }

  signup(event){
    event.preventDefault();
    if (this.validate()) {
      this.account.user.username = this.account.email;
      this.service.signup(this.account,d =>{ 
        if (d.Code == 200 || d.Code == "200") {
          this.router.navigate(['']);        
        }else{
          alert(d.Message);
        }
      })
      .subscribe({
        next:(resp)=>{
        },
        error:null
      });
      
    }
  }
  validate(){
    try {
      this.validateString(this.account.name, "Informe seu nome primeiro.");
      this.validateString(this.account.last_name, "Informe seu sobrenomenome primeiro.");
      this.validateCpf();
      this.validateString(this.account.email, "Informe seu e-mail primeiro. Ele será seu usuário.");
      this.validateString(this.account.phone, "Informe seu telefone primeiro.");
      this.validateString(this.account.enterprise.name, "Informe o nome da empresa primeiro.");
      this.validateCNPJ();
      this.validateString(this.account.address.postal_code, "Informe CEP primeiro.");
      this.validateString(this.account.address.address, "Informe seu nome primeiro.");
      this.validateString(this.account.address.number, "Informe número primeiro. Ou S/N para endereços sem número.");
      this.validateString(this.account.address.state, "Informe o estado primeiro.");
      this.validateString(this.account.address.city, "Informe a cidade primeiro.");
      this.validatePassword();
    } catch (error) {
      alert(error);
      return false;
    }
    return true;
  }

  validatePassword(){
    this.validateString(this.account.user.password, "Informe a senha primeiro.");
    this.validateString(this.confirmPassword, "Confirme a senha primeiro.");
    
    if (this.account.user.password.length < 8) {
      throw new Error("A senha precisa ter no mínimo 8 caracteres.");
    }
    
    if (this.account.user.password != this.confirmPassword) {
      throw new Error("A senha e a confirmação precisam ser iguais.");
    }
  }

  validateString(str:string, message:string){
      if (str === undefined||
        str.trim() === ""
        ) {
        throw new Error(message);        
      }
  }

  validateCpf(){
    this.validateString(this.account.cpf, "Informe seu cpf primeiro.");

    if (this.account.cpf.length < 11) {
      throw new Error("CPF inválido.");      
    }

    var dv1 = this.CalculateCpfDv1(this.account.cpf);
    var dv2 = this.CalculateCpfDv2(this.account.cpf,dv1);

    this.ValidateDV(this.account.cpf,9, dv1, dv2,"CPF inválido.");
  }

  ValidateDV(value: string,index:number, dv1: number, dv2: number, message:string) {
    var digit = `${dv1}${dv2}`;
    if (value.substr(index,2) !== digit)
    {
        throw new Error(message);
    }
    
  }

  
  CalculateCpfDv1(cpf:string ): number
  {
      var weight = 1;
      var str = cpf.substr(0, 9);
      var sums: Array<number> = [];
      for (let i = 0; i < str.length; i++) {
        const c = str[i];
        var digit = parseInt(c);
        sums.push(digit * weight);
        weight++;
      }
     

      var sum = sums.reduce((previous, current )=>{
        return current + previous;
      });

      var result = sum % 11;
      return result < 10 ? result : 0;
  }

  CalculateCpfDv2(cpf:string, dv1:number)
  {
      var weight = 0;
      var str = cpf.substr(0, 9);
      var sums = new Array<number>();

      for (let i = 0; i < str.length; i++) {
        const c = str[i];
        var digit = parseInt(c);
        sums.push(digit * weight);
        weight++;
      }
     
      var sum = sums.reduce((previous, current )=>{
        return current + previous;
      });

      sum += dv1;

      var result = sum % 11;
      return result < 10 ? result : 0;
  }

  validateCNPJ(){
    this.validateString(this.account.enterprise.cnpj, "Informe o cnpj primeiro.");
    var dv1 = this.CalculateCnpjDv1(this.account.enterprise.cnpj);  
    var dv2 = this.CalculateCnpjDv2(this.account.enterprise.cnpj, dv1);
    this.ValidateDV(this.account.enterprise.cnpj,12,dv1,dv2, "CNPJ inválido.");
      
  }
  

  CalculateCnpjDv2(cnpj: string, dv1:number): number {
    var weights = [6, 5,	4,	3,	2,	9,	8,	7,	6,	5,	4,	3,	2];
    var sums = [];
    for (let i = 0; i < weights.length; i++) {
      const weight = weights[i];
      const c = parseInt(cnpj[i]);
      sums.push(c * weight);      
    }

    //sums.push(dv1);
    var sum = sums.reduce((previous, current )=>{
      return current + previous;
    });
    var result = sum % 11;
    return result < 2 ? 0: 11 - result;
  }

  CalculateCnpjDv1(cnpj: string): number {
    var weights = [5,	4,	3,	2,	9,	8,	7,	6,	5,	4,	3,	2];
    var sums = [];

    for (let i = 0; i < weights.length; i++) {
      const weight = weights[i];
      const c = parseInt(cnpj.charAt(i));
      sums.push(c * weight);      
    }

    var sum = sums.reduce((previous, current )=>{
      return current + previous;
    });
    var result = sum % 11;
    return result < 2 ? 0: 11 - result;
  }

  complete(){
    this.router.navigate(['home']);
  }
}
