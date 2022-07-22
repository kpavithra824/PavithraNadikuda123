import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Search } from './search.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private http: HttpClient, private _router: Router) { }

  ngOnInit(): void {
  }

  GetFlightDetails() {

    
    this.http.get("https://localhost:44305/api/1.0/flight/search?fromplace=" + this.SearchModel.fromPlace).subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.SearchModels = res;
  }
  SearchModel: Search = new Search();
  SearchModels: Array<Search> = new Array<Search>();

  BookFlight()
   {
    //console.log("Navigate to Booking");
    this._router.navigate(['Booking/Add']);
  }
}
