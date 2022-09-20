using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class RideEntity : BaseEntity
    {
        public Guid RideId { get; set; }

        public UserEntity CreatedBy { get; set; } 

        public DateTime CreatedDate { get; set; }

        public DateTime RideActivation { get; set; }

        public int NumberOfSeats { get; set; }

        public bool OnlyWomen { get; set; }

        public string SourceName { get; set; }

        public string DestinationName { get; set; } 

        public string Status { get; set; }
        
    }
}
