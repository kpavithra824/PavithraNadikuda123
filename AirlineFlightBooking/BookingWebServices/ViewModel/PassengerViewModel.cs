using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.ViewModel
{
    public class PassengerViewModel
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerAge { get; set; }
        public string Meal { get; set; }
        public string SeatNumber { get; set; }
        public string Trip { get; set; }
        public int? BookingId { get; set; }
        public string Pnr { get; set; }

    }
}
