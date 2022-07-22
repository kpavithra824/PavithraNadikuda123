import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Flight } from './flightschedule.model';
import { FlightScheduleModule } from './flightschedule.module';

@Component({
  selector: 'app-flight-schedule',
  templateUrl: './flight-schedule.component.html'
  
})
export class FlightScheduleComponent implements OnInit {
FlightModel:Flight=new Flight();
FlightModels:Flight=new Flight();
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  GetFlightData()
  {
    console.log("hi");
   // this.http.get("https://localhost:44358/api/1.0/flight/airline").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }
  GetFromServer(res: any) {
    console.log(res);
    this.FlightModels = res;
 }
  AddFlight()
  {
    var flightdto = {
AirlineName: this.FlightModel.airlineName,
FlightNumber: this.FlightModel.flightNumber,
FromPlace:this.FlightModel.fromPlace,
ToPlace:this.FlightModel.toPlace,
StartDatetime:this.FlightModel.startDatetime,
EndDatetime:this.FlightModel.endDatetime,
ScheduleDays:this.FlightModel.scheduleDays,
InstrumentUsed:this.FlightModel.instrumentUsed,
BusinessClassSeats:Number(this.FlightModel.businessClassSeats),
NonBusinessClassSeats:Number(this.FlightModel.nonBusinessClassSeats),
TicketPrice:this.FlightModel.ticketPrice,
NoOfRows:Number(this.FlightModel.noOfRows),
Meal:this.FlightModel.meal,
AirlineLogo:this.FlightModel.airlineLogo,
     
    }
    console.log(flightdto);
    console.log(this.FlightModel);
    this.http.post("https://localhost:44358/api/1.0/flight/airline/Inventory/add", flightdto).subscribe(res => { this.GetFlightData(); console.log(res) }, res => console.log(res));
      this.FlightModel = new Flight();
    
  }
 

}
