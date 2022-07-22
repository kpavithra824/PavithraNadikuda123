using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Controllers
{
    [Route("api/1.0/flight/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        FightAirlineDBContext dbAirline;
        public SearchController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;                
        }

        //[HttpPost]
        //public IActionResult SearchFlight()
        //{

        //    return Ok();
        //}

        [HttpGet]
        public IEnumerable<TblFlightSchedule> search(string fromPlace/*, string toplace*//*,DateTime fromdate*/)
        {
            var data = dbAirline.TblFlightSchedules;
            List<TblFlightSchedule> lst = new List<TblFlightSchedule>();
            foreach (var dr in data)
            {
                if (dr.FromPlace == fromPlace/* && dr.ToPlace == toplace *//*&& dr.FromDateTime == fromdate*/ )
                {
                    lst.Add(dr);
                }
            }
            return lst;

            
        }
    }
}
