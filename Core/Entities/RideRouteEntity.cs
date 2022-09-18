using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class RideRouteEntity : BaseEntity
    {
        public Guid RideRouteId { get; set; }

        public string SourceName { get; set; }

        public string DestinationName { get; set; } 

        public int PassengersCount { get; set; }
    }
}
