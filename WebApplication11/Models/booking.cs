using System;
namespace BookingModels
{
    public class Booking
    {
        public int id { get; set; }
        public int event_id { get; set; }
        public string user_id { get; set; }
        public DateTime createdat { get; set; }

        public Booking()
        {
            createdat = DateTime.UtcNow;
        }
    }
}
