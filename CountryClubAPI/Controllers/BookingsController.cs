using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllBookings()
        {
            var bookings = _context.Bookings;

            return new JsonResult(bookings);
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            //if (!ModelState.IsValid)
            //{
            //    Response.StatusCode = 400;
            //    return BadRequest();
            //}

            _context.Bookings.Add(booking);
            _context.SaveChanges();
            //Response.StatusCode = 201;

            return new JsonResult(booking);

        }

    }
}
