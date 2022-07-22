using AirlineMicroServices.Models;
using AirlineMicroServices.ViewModel;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMicroServices.Controllers
{
    [Route("api/1.0/flight/airline")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IBus bus;
        FightAirlineDBContext dbAirline;
     //   private readonly ILogger<RegisterController> logger;

        public RegisterController(FightAirlineDBContext _dbAirline, ILogger<RegisterController> _logger,IBus _bus)
        {
            dbAirline = _dbAirline;
           // logger = _logger;
            bus = _bus;
        }

        [Route("register")]
        [HttpPost]
        // [Authorize]
        public IActionResult Register(AirlineViewModel airlineViewModel)
        {
            try
            {
                TblAirline airline = new TblAirline();
                airline.AirlineName = airlineViewModel.AirlineName;
                airline.AirlineLogo = airlineViewModel.AirlineLogo;
                airline.Contact = airlineViewModel.Contact;
                airline.Address = airlineViewModel.Address;
                airline.IsBlock = Convert.ToBoolean(airlineViewModel.IsBlock);
                dbAirline.TblAirlines.Add(airline);
                dbAirline.SaveChanges();
                return Ok("Record Added Successfully");
            }
            catch
            {
                return BadRequest();
            }
        }

        //[Route("register")]
        //[HttpPost]
        //public async Task<IActionResult> Register(AirlineViewModel airlineViewModel)
        //{
        //    if (airlineViewModel != null)
        //    {
        //        Uri uri = new Uri("rabbitmq://localhost/registerairlinequeue");
        //        var endpoint = await bus.GetSendEndpoint(uri);
        //        await endpoint.Send(airlineViewModel);
        //        return Ok();
        //    }

        //   // logger.LogError("AirlineController-Error while calling the Airline consumer from Producer");
        //    return BadRequest();
        //}



        [HttpPut]      
        public IActionResult putData(AirlineViewModel airlineViewModel)
        {
            try 
            {
                if (dbAirline.TblAirlines.Any(x => x.AirlineId == airlineViewModel.AirlineId))
                {
                    var data = dbAirline.TblAirlines.Where(x => x.AirlineId == airlineViewModel.AirlineId).FirstOrDefault();
                    data.AirlineName = airlineViewModel.AirlineName;
                    data.Contact = airlineViewModel.Contact;
                    data.Address = airlineViewModel.Address;
                    data.AirlineLogo = airlineViewModel.AirlineLogo;
                    data.IsBlock = Convert.ToBoolean(airlineViewModel.IsBlock);
                    dbAirline.TblAirlines.Update(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully updated.");
                }

                return BadRequest("Record not found.");
            }
            catch
            {
                return BadRequest("Record Update Failed.");
            }
            
        }

        [HttpDelete]      
        public IActionResult deleteData(int airlineId)
        {
            try 
            {
                if (dbAirline.TblAirlines.Any(x => x.AirlineId == airlineId))
                {
                    var data = dbAirline.TblAirlines.Where(x => x.AirlineId == airlineId).FirstOrDefault();
                    dbAirline.TblAirlines.Remove(data);
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

        [HttpGet]
        public List<TblAirline> getAirlineData()
        {
            return dbAirline.TblAirlines.ToList();
        }

        //[HttpGet]      

        //public string getData()
        //{
        //    return "OK";
        //}



        //public List<TblAirline> FindAll()
        //{
        //    return dbAirline.TblAirlines.ToList();
        //}
    }
}
