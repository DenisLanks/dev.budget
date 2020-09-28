import { User } from "./user.model";
import { Address } from "./address.model";
import { Enterprise } from "./enterprise.model";

export class Account {
    name: string;
    last_name: string;
    cpf: string;
    email: string;
    phone: string;
    user:User
    address: Address;
    enterprise:Enterprise;

    /**
     *
     */
    constructor() {
        this.user = new User();
        this.address = new Address();
        this.enterprise = new Enterprise();
    }
}