using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class BookingEntity : BaseEntity
    {
        public Guid RideId { get; set; }
        
        public Guid UserId { get; set; }

        public int NumberOfSeats { get; set; }

        public override string ToString()
        {
            return string.Format("User {0} booked ride {1}, allocated {2} number of seats",
                RideId,
                UserId,
                NumberOfSeats);
        }
    }
}
