using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class BookingEntity : BaseEntity
    {
        public Guid BookingId { get; set; }

        public RideEntity Ride { get; set; }
        
        public UserEntity User { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
