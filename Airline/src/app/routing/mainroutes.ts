
import { DashboardComponent } from "../dashboard/dashboard.component";
import { HomeComponent } from "../home/home.component";
import { LoginComponent } from "../login/login.component";
import { RegisterComponent } from "../register/register.component";


export const Mainroutes= [
  { path: '', component: HomeComponent },
  { path: 'Login',component: LoginComponent},
  { path: 'Register',component: RegisterComponent},
  { path: 'dashboard',component: DashboardComponent},
  { path: 'Home', component:HomeComponent },
  { path: 'Airline', loadChildren:()=>import('../airline/airline.module').then(m=>m.AirlineModule) },
  { path: 'FlightSchedule', loadChildren:()=>import('../flight-schedule/flightschedule.module').then(m=>m.FlightScheduleModule) },
  { path: 'ListofFlightSchedule', loadChildren:()=>import('../flight-schedule/flightschedule.module').then(m=>m.FlightScheduleModule) },
  { path: 'Booking', loadChildren:()=>import('../booking/booking.module').then(m=>m.BookingModule) },
  { path: 'Search', loadChildren:()=>import('../search/search.module').then(m=>m.SearchModule) },
  { path: 'SearchByEmailId', loadChildren:()=>import('../search/search.module').then(m=>m.SearchModule) },
  { path: 'SearchByPNR', loadChildren:()=>import('../search/search.module').then(m=>m.SearchModule) }


];



