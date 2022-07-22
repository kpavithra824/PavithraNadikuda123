using AirlineConsumerMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineConsumerMicroservices.Interfaces
{
    public interface IAirlineImplementation
    {
        public void registerAirline(Common.AirlineViewModel airlineViewModel);
        
    }
}
