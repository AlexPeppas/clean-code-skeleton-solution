
using Newtonsoft.Json;

namespace GotSpaceSolution.Core
{
    [JsonObject]
    public sealed class JoinRide
    {
        [JsonProperty(PropertyName = "rideId", Required = Required.Always)]
        public Guid RideId { get; set; }

        [JsonProperty(PropertyName = "numberOfSeatsRequested", Required = Required.Always)]
        public int NumberOfSeatsRequested { get; set; }

    }
}
