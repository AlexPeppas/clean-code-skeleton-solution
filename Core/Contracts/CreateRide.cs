﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotSpaceSolution.Core
{
    [JsonObject]
    public sealed class CreateRide
    {
        [JsonProperty(PropertyName = "sourceName", Required = Required.Always)]
        public string SourceName { get; set; }

        [JsonProperty(PropertyName = "destinationName", Required = Required.Always)]
        public string DestinationName { get; set; }

        [JsonProperty(PropertyName = "numberOfSeats", Required = Required.Always)]
        public int NumberOfSeats { get; set; }
    }
}
