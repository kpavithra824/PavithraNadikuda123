using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWebServices.Models;
using TicketWebServices.ViewModel;

namespace TicketWebServices.Controllers
{
    [Route("api/1.0/flight/ticket")]
    [ApiController]
    public class ticketController : ControllerBase
    {

       
        FightAirlineDBContext dbFlights;
        public ticketController( FightAirlineDBContext _dbFlights)
        {
            dbFlights = _dbFlights;
           
        }

        [HttpGet]
        [Route("pnr")]
        public IActionResult GetPnr(string pnr)
        {
            try
            {
                List<PassengerViewModel> lstpassengerView = new List<PassengerViewModel>();
                if (pnr != null && dbFlights.TblPassengers.Any(x => x.Pnr == pnr))
                {

                    var passengers = dbFlights.TblPassengers.Where(x => x.Pnr == pnr).ToList();
                    foreach (TblPassenger pass in passengers)
                    {
                        PassengerViewModel item = new PassengerViewModel();
                        
                        item.BookingId = pass.BookingId;
                        item.PassengerName = pass.PassengerName;
                        item.PassengerAge = pass.PassengerAge;
                        item.Meal =pass.Meal;
                        item.Pnr = pass.Pnr;
                        item.SeatNumber = pass.SeatNumber;
                        lstpassengerView.Add(item);
                    }
                }

                return Ok(lstpassengerView);
            }
            catch
            {
                return BadRequest("Records not found");
            }
        }



    }
}
