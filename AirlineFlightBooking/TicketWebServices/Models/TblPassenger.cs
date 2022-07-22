using System;
using System.Collections.Generic;

#nullable disable

namespace TicketWebServices.Models
{
    public partial class TblPassenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int? PassengerAge { get; set; }
        public string Meal { get; set; }
        public string SeatNumber { get; set; }
        public string Trip { get; set; }
        public int? BookingId { get; set; }
        public string Pnr { get; set; }

        public virtual TblBooking Booking { get; set; }
    }
}
