import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'

})
export class HomeComponent implements OnInit {

  constructor() { }
  imageurl:any="././assets/airline.png";
  ngOnInit(): void {
  }

}
