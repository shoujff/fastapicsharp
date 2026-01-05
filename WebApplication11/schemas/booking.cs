using System;
using System.ComponentModel.DataAnnotations;

namespace Booking
{
    public class BookingRequest
    {
        internal readonly DateTime createdat;
        internal readonly int id;

        public int event_id { get; set; }


        public string user_id { get; set; }
        public BookingRequest()
        {
            if (user_id.Length < 1)
            {
                throw new ArgumentException("user_id должен содержать минимум 1 символ", nameof(user_id));
            }
            if (event_id < 0)
            {
                throw new ArgumentException("event_id должен быть больше 0", nameof(event_id));
            }
        }
    }


    public class BookingResponse
    {
        public int id { get; set; }
        public int event_id { get; set; }
        public string user_id { get; set; }
        public DateTime createdat { get; set; }


        public BookingResponse( int id, int eventId, string userId, DateTime createdAt)
        {
            this.id = id;
            this.event_id = eventId;
            this.user_id = userId;
            this.createdat = createdAt;
        }
    }
}