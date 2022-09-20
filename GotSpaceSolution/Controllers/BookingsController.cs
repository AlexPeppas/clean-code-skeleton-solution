using GotSpaceSolution.Core;
using Microsoft.AspNetCore.Mvc;

namespace GotSpaceSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> logger;
        private readonly IBookingService bookingService;

        public BookingsController(ILogger<BookingsController> logger, IBookingService bookingService)
        {
            this.logger = logger;
            this.bookingService = bookingService;
        }

        [HttpPost(Name = "CreateBooking")]
        public async Task<IActionResult> CreateBooking(BookingEntity entity, CancellationToken cancellationToken = default)
        {
            await bookingService.CreateNewBookingAsync(entity, cancellationToken);

            return Ok();
        }
    }
}