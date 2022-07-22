import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SearchEmail } from './searchbyemailid.model';

@Component({

  templateUrl: './searchbyemailid.component.html'

})
export class SearchByEmailIdComponent implements OnInit {

  constructor(private http:HttpClient) { }
 SearchEmailModel:SearchEmail=new SearchEmail();
 SearchEmailModels:Array<SearchEmail>=new Array<SearchEmail>();
  ngOnInit(): void {
  }
  SearchEmail()
  {
   // let httparms = new HttpParams().set("emailId",this.SearchEmailModel.emailId);
    //let options = { params: httparms };
  //  this.http.get("https://localhost:44305/api/1.0/flight/search?fromplace="+this.SearchModel.fromPlace).subscribe(res => this.GetFromServer(res), res => console.log(res));
    this.http.get("https://localhost:44333/api/1.0/flight/booking/history?emailId="+this.SearchEmailModel.emailId).subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.SearchEmailModels = res;
 }
}
