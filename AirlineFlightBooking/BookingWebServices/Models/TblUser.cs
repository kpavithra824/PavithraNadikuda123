using System;
using System.Collections.Generic;

#nullable disable

namespace BookingWebServices.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public int? NoOfSeats { get; set; }
        public string SeatsNumbers { get; set; }
        public string Meal { get; set; }
        public int? Pnr { get; set; }
        public string Cancelled { get; set; }
    }
}
