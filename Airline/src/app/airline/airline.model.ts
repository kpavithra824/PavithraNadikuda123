import { NgForm, FormGroup, Validators, FormBuilder, FormControl } from "@angular/forms";

export class Airline{
    airlineId:number=0;
    airlineName:string="";
    airlineLogo:string="";
    address:string="";
    contact:string="";
    isBlock:string="";
    formAirlineGroup: FormGroup;//Create
    constructor() {
        var _builder = new FormBuilder();
        this.formAirlineGroup = _builder.group({});
       this.formAirlineGroup.addControl("AirlineNameControl",new FormControl('', Validators.required));
       this.formAirlineGroup.addControl("AirlineLogoControl",new FormControl('', Validators.required));
       this.formAirlineGroup.addControl("AirlineAddressControl",new FormControl('', Validators.required));

      var validationcollection = [];
       validationcollection.push(Validators.required);
       validationcollection.push(Validators.pattern("^[0-9]{10,10}$"))
      this.formAirlineGroup.addControl("AirlineContactControl", new FormControl('', Validators.compose(validationcollection)));

    }
}