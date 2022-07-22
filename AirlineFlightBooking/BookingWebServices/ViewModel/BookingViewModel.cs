using BookingWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public int? SeatsToBook { get; set; }
        public int? FlightId { get; set; }
        public string BookedOn { get; set; }

        public List<PassengerViewModel> Passengers { get; set; }
    }
}
