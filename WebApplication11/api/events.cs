using System;
using System.Collections.Generic;
using BookingReq;
using EventReq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace event_router
{

    [ApiController]
    [Route("api/events")]

    public class EventsContorller : ControllerBase
    {

        private static List<EventResponse> events = new List<EventResponse>();
        private static int nextEventId = 1;
        [HttpPost]
        public ActionResult<EventResponse> CreateEvent(
                [FromBody] EventRequest request,
                [FromQuery] string description,
                [FromQuery] string date)
        {
            var newEvent = new EventResponse(
                   id: nextEventId++,
                   name: request.name,
                   totalSeats: request.total_seats

               );
            events.Add(newEvent);

            return CreatedAtAction(nameof(CreateEvent), newEvent);
        }

    }
}





