using System;
using System.Collections.Generic;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class TblAirline
    {
        public TblAirline()
        {
            TblFlightSchedules = new HashSet<TblFlightSchedule>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public bool? IsBlock { get; set; }

        public virtual ICollection<TblFlightSchedule> TblFlightSchedules { get; set; }
    }
}
