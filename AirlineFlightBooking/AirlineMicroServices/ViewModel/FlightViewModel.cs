using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMicroServices.ViewModel
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public string ScheduleDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeats { get; set; }
        public int? NonBusinessClassSeats { get; set; }
        public  string TicketPrice { get; set; }
        public int? NoOfRows { get; set; }
        public string Meal { get; set; }
        public string AirlineLogo { get; set; }
    }
}
