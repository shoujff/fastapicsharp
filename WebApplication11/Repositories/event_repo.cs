using EventModels;
public class EventRepository
{
    static readonly List<Event> events = new List<Event>();
    private int _nextId = 1;
    public async Task<Event> get_by_id(int eventid)
    {
        var query = events.FirstOrDefault(e => e.id == eventid);
        return await Task.FromResult(query);

    }
    public Task<Event> CreateAsync(string name, int totalSeats)
    {
        var newEvent = new Event
        {
            id = _nextId++,
            name = name,
            total_seats = totalSeats,

        };
        events.Add(newEvent);

        events.Add(newEvent);
        return Task.FromResult(newEvent);
    }
}

