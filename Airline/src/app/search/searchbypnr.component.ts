import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SearchPNR } from './searchbypnr.model';

@Component({

  templateUrl: './searchbypnr.component.html'

})
export class SearchByPNRComponent implements OnInit {


  constructor(private http:HttpClient) { }

 SearchPNRModel:SearchPNR= new SearchPNR();
 SerachPNRModels:Array<SearchPNR>= new Array<SearchPNR>();
  ngOnInit(): void {
  }
  SearchPNR(){
    let httparms = new HttpParams().set("pnr",this.SearchPNRModel.pnr);
    let options = { params: httparms };
    this.http.get("https://localhost:44318/api/1.0/flight/ticket/pnr",options).subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.SerachPNRModels = res;
 }
 DeletePNR(cust:SearchPNR){
  console.log(cust);
  let httparms = new HttpParams().set("pnr", cust.pnr);
  let options = { params: httparms };
  //this.AirlineModels=this.arrayRemove( this.AirlineModels,Airline)
  this.http.delete("https://localhost:44333/api/1.0/flight/booking", options).subscribe(res => { this.SearchPNR(); console.log(res) }, res => console.log(res));

 }
}
