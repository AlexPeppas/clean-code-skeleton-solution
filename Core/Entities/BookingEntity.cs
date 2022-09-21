using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class BookingEntity : BaseEntity
    {
        public Guid RideId { get; set; }
        
        public Guid UserId { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
