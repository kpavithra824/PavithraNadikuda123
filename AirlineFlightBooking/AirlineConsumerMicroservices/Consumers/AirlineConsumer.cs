using AirlineConsumerMicroservices.Models;
using AirlineConsumerMicroservices.ViewModel;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineConsumerMicroservices.Consumers
{
    public class AirlineConsumer : IConsumer<Common.AirlineViewModel>
    {
        AirlineImplementation _airlineImplementation = new AirlineImplementation();
        public async Task Consume(ConsumeContext<Common.AirlineViewModel> airlinecontext)
        {           
           _airlineImplementation.registerAirline(airlinecontext.Message);

        }

       
    }
}
