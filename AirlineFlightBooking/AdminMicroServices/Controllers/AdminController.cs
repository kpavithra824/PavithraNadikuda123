using AdminMicroServices.Models;
using AdminMicroServices.Services;
using AdminMicroServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        FightAirlineDBContext dbAirline;

        public AdminController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;

        }

        [HttpGet]
       // [Authorize]
        public string getData()
        {
            return "OK";
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult postData(AirlineViewModel airlineViewModel)
        //{
        //    try
        //    {
        //        TblAirline airline = new TblAirline();
        //        airline.AirlineName = airlineViewModel.AirlineName;
        //        airline.AirlineLogo = airlineViewModel.AirlineLogo;
        //        airline.Contact = airlineViewModel.Contact;
        //        airline.Address = airlineViewModel.Address;
        //        dbAirline.TblAirlines.Add(airline);
        //        dbAirline.SaveChanges();
        //        return Ok("Record Added Successfully");
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }

        //}

        //[HttpPut]
        //[Authorize]
        //public IActionResult putData(AirlineViewModel airlineViewModel)
        //{
        //    if (dbAirline.TblAirlines.Any(x => x.AirlineId == airlineViewModel.AirlineId))
        //    {
        //        var data = dbAirline.TblAirlines.Where(x => x.AirlineId == airlineViewModel.AirlineId).FirstOrDefault();
        //        data.AirlineName = airlineViewModel.AirlineName;
        //        data.Contact = airlineViewModel.Contact;
        //        data.Address = airlineViewModel.Address;
        //        data.AirlineLogo = airlineViewModel.AirlineLogo;
        //        dbAirline.TblAirlines.Update(data);
        //        dbAirline.SaveChanges();
        //        return Ok("Record have been successfully updated.");
        //    }

        //    return BadRequest("Record not found.");
        //}
        //[HttpDelete]
        //[Authorize]
        //public IActionResult deleteData(int Id)
        //{
        //    if (dbAirline.TblAirlines.Any(x => x.AirlineId == Id))
        //    {
        //        var data = dbAirline.TblAirlines.Where(x => x.AirlineId == Id).FirstOrDefault();
        //        dbAirline.TblAirlines.Remove(data);
        //        dbAirline.SaveChanges();
        //        return Ok("Record have been successfully deleted.");
        //    }

        //    return BadRequest("Record not found.");
        //}


    }
}
