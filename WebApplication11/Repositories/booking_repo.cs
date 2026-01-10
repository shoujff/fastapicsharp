using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BookingModels;
public class BookingRepository
{
    private readonly List<Booking> bookings = new List<Booking>();
    private int _nextId = 1;
    public async Task<int> count_by_event(int event_id)
    {
        int query = bookings.Count(b => b.event_id == event_id);
        return await Task.FromResult(query);
    }
    public async Task<bool> exists_for_user(string userid, int eventid)
    {
        bool query = bookings.Any(b => b.event_id == eventid && b.user_id == userid);
        return await Task.FromResult(query);
        }
    public Task<Booking> create(string userid, int eventid)
    {
        
        var booking = new Booking
        {
           id = _nextId++, // 
           event_id = eventid,
            user_id = userid,
            createdat = DateTime.UtcNow
        };
        bookings.Add(booking);
        return Task.FromResult(booking);
    }
}
