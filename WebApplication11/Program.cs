using BookingModels;
using event_router;
using booking_router;
using EventModels;
using HTTPException;
using booking_repo;
using event_repo;
public  class DataStore
{
   
   BookingRepository bookingRepository = new BookingRepository();
    EventRepository eventRepository = new EventRepository();
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("api/events", () => EventRepository.events);

        app.MapPost("api/events", (Event newEvent) =>
        {
            int newId;
            lock (EventRepository.events) {
                newId = EventRepository.events.Count > 0 ? EventRepository.events.Max(e => e.id) + 1 : 1;
                newEvent.id = newId;
                EventRepository.events.Add(newEvent);
            }
                return Results.Created($"api/events/{newId}", newEvent);
            
        });

        app.MapGet("api/bookings", () => BookingRepository.bookings);

        app.MapPost("api/bookings", (Booking booking) =>
        {
           
            var ev = EventRepository.events.FirstOrDefault(e => e.id == booking.event_id);
            if (ev == null)
            {
                return Results.BadRequest("Event not found");
            }
            int newId;
            lock (BookingRepository.bookings)
            {
                newId = BookingRepository.bookings.Count > 0 ? BookingRepository.bookings.Max(b => b.id) + 1 : 1;
                booking.id = newId;
                booking.createdat = DateTime.UtcNow;
                BookingRepository.bookings.Add(booking);
            }
            return Results.Created($"api/bookings/{newId}", booking);
        });
       
       await app.RunAsync();
    }
}