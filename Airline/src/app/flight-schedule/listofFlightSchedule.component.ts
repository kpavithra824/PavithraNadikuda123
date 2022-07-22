import { HttpClient, HttpParams } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Flight } from "./flightschedule.model";
import { ListFlight } from "./ListFlightSchedule.Model";

@Component({

  templateUrl: './listofFlightSchedule.component.html'

})
export class ListofFlightScheduleComponent implements OnInit {



  constructor(private http: HttpClient) { }
  ListFlightScheduleModel: ListFlight = new ListFlight();
  ListFlightScheduleModels: Array<ListFlight> = new Array<ListFlight>();

  ngOnInit(): void {
    this.GetFlightData();
  }
  GetFlightData()
  { 
   this.http.get("https://localhost:44358/api/1.0/flight/airline/Inventory").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.ListFlightScheduleModels = res;
 }

  EditFlight(cust: ListFlight) {
    this.ListFlightScheduleModel = cust;
  }
  DeleteFlight(cust: ListFlight) {
    console.log(cust);
    let httparms = new HttpParams().set("flightId", cust.flightId);
    let options = { params: httparms };
    this.http.delete("https://localhost:44358/api/1.0/flight/airline/Inventory", options).subscribe(res => { this.GetFlightData(); console.log(res) }, res => console.log(res));
  }


}
