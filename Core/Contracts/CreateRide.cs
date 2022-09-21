using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "allocatedNumberOfSeats", Required = Required.Always)]
        public int AllocatedNumberOfSeats { get; set; }

        [JsonProperty(PropertyName = "totalNumberOfSeats", Required = Required.Always)]
        public int TotalNumberOfSeats { get; set; }

        [JsonProperty(PropertyName = "createdBy", Required = Required.Always)]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "rideActivation", Required = Required.Always)]
        public DateTime RideActivation { get; set; }

        [JsonProperty(PropertyName = "onlyWomen", Required = Required.Always)]
        public bool OnlyWomen { get; set; }
    }
}
