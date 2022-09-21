using GotSpaceSolution.Core;
using Microsoft.AspNetCore.Http.Json;
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

        [HttpPost("/createBooking")]
        public async Task<IActionResult> CreateBooking(BookingEntity entity, CancellationToken cancellationToken = default)
        {
            await bookingService.CreateNewBookingAsync(entity, cancellationToken);
            return Ok();
        }

        [HttpGet("/getBooking")]
        public async Task<IActionResult> GetBooking(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var bookingEntity = await bookingService.ReadAsync(id, cancellationToken);
                return Ok(bookingEntity);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("/CancelBooking")]
        public async Task CancelBooking(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                await bookingService.CancelBookingAsync(id, cancellationToken);
                Ok();
            }
            catch (Exception)
            {
                NotFound();
            }
        }

        [HttpPost("/update")]
        public async Task<IActionResult> UpdateAsync(Guid id, int newNumberOfSeats, CancellationToken cancellationToken)
        {
            var updated = await bookingService.UpdateAsync(id, newNumberOfSeats, cancellationToken);

            if (updated)
                return Ok();

            return BadRequest("There are not sufficient seats for your request");
        }
    }
}