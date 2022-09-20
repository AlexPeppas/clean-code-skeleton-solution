
using Newtonsoft.Json;

namespace GotSpaceSolution.Core
{
    [JsonObject]
    public sealed class FilterRides
    {
        [JsonProperty(PropertyName = "sourceName", Required = Required.Always)]
        public string SourceName { get; set; }

        [JsonProperty(PropertyName = "destinationName", Required = Required.AllowNull)]
        public string DestinationName { get; set; }

        [JsonProperty(PropertyName = "numberOfSeats", Required = Required.AllowNull)]
        public int NumberOfSeats { get; set; }

        [JsonProperty(PropertyName = "rideActivation", Required = Required.AllowNull)]
        public DateTime RideActivation { get; set; }

        [JsonProperty(PropertyName = "onlyWomen", Required = Required.AllowNull)]
        public bool OnlyWomen { get; set; }

    }
}
