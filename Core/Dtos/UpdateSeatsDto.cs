using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotSpaceSolution.Core
{
    public class UpdateSeatsDto //Data Transfer Object
    {
        public Guid RideId { get; set; }

        public int BookingNumberOfSeats { get; set; }

        public bool  ToAdd { get; set; }
    }
}
