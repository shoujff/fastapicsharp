using System;
namespace BookingModels;

public class BookingModel
{
    public int id { get; set; }
    public int event_id { get; set; }
    public string user_id { get; set; }
    public DateTime createdat { get; internal set; }

    public BookingModel()
    {
        createdat = DateTime.UtcNow;
    }
}
