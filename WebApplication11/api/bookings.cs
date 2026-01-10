using Microsoft.AspNetCore.Mvc;
using System;
using BookingReq;
using System.Collections.Generic;

namespace booking_router
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {

        private static List<BookingResponse> bookings = new List<BookingResponse>();
        private static int nextId = 1;

        [HttpPost("reserve")]
        public ActionResult<BookingResponse> Reserve(
            [FromBody] BookingRequest request,
            [FromQuery] int? event_id,
            [FromQuery] string user_id)
        {
            int id = nextId++;
            var createdAt = DateTime.UtcNow;


            var booking = new BookingResponse(id, request.event_id, request.user_id, createdAt);

            bookings.Add(booking);
            return CreatedAtAction(nameof(Reserve), booking);
        }
    }
}
    