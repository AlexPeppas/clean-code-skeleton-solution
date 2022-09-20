using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotSpaceSolution.Core
{
    [JsonObject]
    public sealed class CreateBooking
    {
        [JsonProperty(PropertyName = "rideId", Required = Required.Always)]
        public Guid RideId { get; set; }

        [JsonProperty(PropertyName = "userId", Required = Required.Always)]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "numberOfSeats", Required = Required.Always)]
        public int NumberOfSeats { get; set; }
    }
}
