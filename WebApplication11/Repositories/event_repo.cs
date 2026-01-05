using EventModels;
public class EventRepository
{
    static readonly List<EventModel> events = new List<EventModel>();
    private int _nextId = 1;
    public async Task<EventModel> get_by_id(int eventid)
    {
        var query = events.FirstOrDefault(e => e.id == eventid);
        return await Task.FromResult(query);

    }
    public Task<EventModel> CreateAsync(string name, int totalSeats)
    {
        var newEvent = new EventModel
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

