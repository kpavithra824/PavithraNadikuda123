using System;
using System.Collections.Generic;

#nullable disable

namespace SearchWebServices.Models
{
    public partial class TblBooking
    {
        public TblBooking()
        {
            TblPassengers = new HashSet<TblPassenger>();
        }

        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public int? SeatsToBook { get; set; }
        public int? FlightId { get; set; }
        public DateTime? BookedOn { get; set; }

        public virtual ICollection<TblPassenger> TblPassengers { get; set; }
    }
}
