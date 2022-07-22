import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { Airline } from './airline.model';

@Component({
  
  templateUrl: './airline.component.html'
 
})
export class AirlineComponent implements OnInit {
   
  constructor(private http:HttpClient) { 

  }

  title="Airline Project";
  AirlineModel:Airline= new Airline();
  AirlineModels:Array<Airline> = new Array<Airline>();
  ngOnInit(): void {
    this.GetAirlineData();
  }
  GetAirlineData() {
    this.http.get("https://localhost:44358/api/1.0/flight/airline").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.AirlineModels = res;
 }

  AddAirline(){
  //  for(let i=0;i<this.AirlineModels.length;i++){
   //   if(this.AirlineModel.airlineId==this.AirlineModels[i].airlineId){
   //     this.AirlineModels=this.arrayRemove(this.AirlineModels,this.AirlineModel)
        
   //   }
   // }
   // this.AirlineModels.push(this.AirlineModel);
  //  console.log(this.AirlineModels);
  var airlinedto = {
    AirlineName: this.AirlineModel.airlineName,
    AirlineLogo: this.AirlineModel.airlineLogo,
    Address: this.AirlineModel.address,
    Contact: this.AirlineModel.contact,
    IsBlock: this.AirlineModel.isBlock
  }
  console.log(airlinedto);
  console.log(this.AirlineModel);
  this.http.post("https://localhost:44358/api/1.0/flight/airline/register", airlinedto).subscribe(res => { this.GetAirlineData(); console.log(res) }, res => console.log(res));
    this.AirlineModel = new Airline();
    
  }
  EditAirline(cust:Airline){
    this.AirlineModel = cust;
  }
  DeleteAirline(cust:Airline){
    console.log(cust);
    let httparms = new HttpParams().set("AirlineId", cust.airlineId);
    let options = { params: httparms };
    //this.AirlineModels=this.arrayRemove( this.AirlineModels,Airline)
    this.http.delete("https://localhost:44358/api/1.0/flight/airline", options).subscribe(res => { this.GetAirlineData(); console.log(res) }, res => console.log(res));
    
  }
  arrayRemove(arr:any,value:any){
    return arr.filter(function(sample:any){
      return sample!=value;
    });
  }
  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.AirlineModel.formAirlineGroup.controls[controlname].hasError(typeofvalidator);
  }

}
