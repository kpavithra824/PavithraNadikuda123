﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineConsumerMicroservices.ViewModel
{
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string IsBlock { get; set; }
    }
}
