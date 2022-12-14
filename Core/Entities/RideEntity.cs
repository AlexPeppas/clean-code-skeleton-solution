using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public class RideEntity : BaseEntity
    {
        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime RideTime { get; set; }

        public int AllocatedNumberOfSeats { get; set; }

        public int TotalNumberOfSeats { get; set; }
        
        public bool OnlyWomen { get; set; }

        public string SourceName { get; set; }

        public string DestinationName { get; set; } 

        public string Status { get; set; }
        
    }
}
