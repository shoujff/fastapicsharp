using BookingModels;
using EventModels;
public static class DataStore
{
    public static List<Event> Events { get; } = new List<Event>();
    public static List<Booking> Bookings { get; } = new List<Booking>();
    static async void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("api/events", () => DataStore.Events);

        app.MapPost("api/events", (Event newEvent) =>
        {
            int newId = DataStore.Events.Count > 0 ? DataStore.Events.Max(e => e.id) + 1 : 1;
            newEvent.id = newId;
            DataStore.Events.Add(newEvent);
            return Results.Created($"/events/{newId}", newEvent);
        });

        app.MapGet("/bookings", () => DataStore.Bookings);

        app.MapPost("/bookings", (Booking booking) =>
        {
           
            var ev = DataStore.Events.FirstOrDefault(e => e.id == booking.event_id);
            if (ev == null)
                return Results.BadRequest("Event not found");

            int newId = DataStore.Bookings.Count > 0 ? DataStore.Bookings.Max(b => b.id) + 1 : 1;
            booking.id = newId;
            booking.createdat = DateTime.UtcNow;
            DataStore.Bookings.Add(booking);
            return Results.Created($"/bookings/{newId}", booking);
        });

        app.Run();
    }
}