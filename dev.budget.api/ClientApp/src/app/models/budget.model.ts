export class Budget {
    devCount: number;
    devTotal: number;
    desCount: number;
    desTotal: number;
    smCount:  number;
    smTotal:  number;
    poCount:  number;
    poTotal:  number;
    duration:  number;
    durTotal:  number;
    total:  number;

    /**
     *
     */
    constructor() {
        this.devCount = 0;
        this.devTotal = 0;
        this.desCount = 0;
        this.desTotal = 0;
        this.duration  = 10;
        this.durTotal  = 0;
        this.poCount = 0;
        this.poTotal = 0;
        this.smCount = 0;
        this.smTotal = 0;
        
    }
}