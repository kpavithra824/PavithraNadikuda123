using AirlineConsumerMicroservices.Interfaces;
using AirlineConsumerMicroservices.Models;
using AirlineConsumerMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineConsumerMicroservices.Consumers
{
    public class AirlineImplementation:IAirlineImplementation
    {
        FightAirlineDBContext dbAirline = new  FightAirlineDBContext();
        public void registerAirline(Common.AirlineViewModel airlineViewModel)
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
            }
            catch
            {
                throw;
            }
        }
    }
}
