export class Booking{
    bookingid:number=0;
    customerName:string="";
    emailId:string="";
    seatsToBook:number=0;
    flightId:number=0;
    bookedOn:string="";   
    passengers:Array<Passenger>=new Array<Passenger>();
   
}

export class Passenger{
    passengerName:string="";
    passengerAge:number=0;
    meal:string="";
    seatNumber:string="";
}