using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Controllers
{
    [Route("api/1.0/flight/booking")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        FightAirlineDBContext dbAirline;
        public bookingController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }

        [HttpGet]
      
        // [Authorize]
        public List<TblBooking> getBookingData()
        {
            return dbAirline.TblBookings.ToList();
        }


        [HttpPost]
        public IActionResult postUserData( BookingViewModel bookviewmodel)
        {
            try
            {
                
                TblBooking booking = new TblBooking();
               
                booking.CustomerName = bookviewmodel.CustomerName;
                booking.EmailId = bookviewmodel.EmailId;
                booking.SeatsToBook = bookviewmodel.SeatsToBook;
                booking.FlightId = bookviewmodel.FlightId;
                booking.BookedOn = Convert.ToDateTime(bookviewmodel.BookedOn);
                dbAirline.TblBookings.Add(booking);

                for(int i = 0; i < bookviewmodel.Passengers.Count; i++)
                {
                    TblPassenger pass = new TblPassenger();
                    // pass.PassengerId = new Int32();
                    pass.PassengerName = bookviewmodel.Passengers[i].PassengerName;
                    pass.PassengerAge = Convert.ToInt32(bookviewmodel.Passengers[i].PassengerAge);
                    pass.BookingId = pass.BookingId = dbAirline.TblBookings.OrderBy(x => x.BookingId).Select(x => i == 0 ? x.BookingId + 1 : x.BookingId).LastOrDefault();
                    pass.Meal = bookviewmodel.Passengers[i].Meal;
                    pass.SeatNumber = bookviewmodel.Passengers[i].SeatNumber;
                    pass.Trip = bookviewmodel.Passengers[i].Trip;
                    Random random = new Random();
                    long ran = random.Next(1000000, 9999999);
                    pass.Pnr = ran.ToString();

                    dbAirline.TblPassengers.Add(pass);
                    dbAirline.SaveChanges();
                }
                dbAirline.SaveChanges();
               return Ok("Record Added Successfully");



            }
            catch
            {
                return BadRequest();
            }
           
        }


        [HttpGet]
        [Route("history")]
        public IActionResult history(string emailId)
        {
            try
            {
                List<BookingViewModel> lstbookingView = new List<BookingViewModel>();
                if (emailId != null && dbAirline.TblBookings.Any(x => x.EmailId == emailId))
                {

                    var book = dbAirline.TblBookings.Where(x => x.EmailId == emailId).ToList();
                    foreach (TblBooking booking in book)
                    {
                        BookingViewModel item = new BookingViewModel();
                        item.BookingId = booking.BookingId;
                        item.CustomerName = booking.CustomerName;
                        item.EmailId = booking.EmailId;
                        item.SeatsToBook = Convert.ToInt32(booking.SeatsToBook);
                        item.FlightId = Convert.ToInt32(booking.FlightId);
                        item.BookedOn = Convert.ToString(booking.BookedOn);


                        lstbookingView.Add(item);
                    }
                }
                return Ok(lstbookingView);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult cancel(string pnr)
        {
            try
            {
                if (dbAirline.TblPassengers.Any(x => x.Pnr == pnr))
                {
                    var data = dbAirline.TblPassengers.Where(x => x.Pnr == pnr).FirstOrDefault();
                    dbAirline.TblPassengers.Remove(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully deleted.");
                }

                return BadRequest("Record not found.");
            }
            catch
            {
                return BadRequest("Record Delete Failed.");
            }
        }

    }
}
