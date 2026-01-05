using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Event
{
    public class EventResponse
    {
        public int id { get; set; }
        public string name { get; set; }

        public int total_seats { get; set; }

        public EventResponse(int id, string name, int totalSeats)
        {
            if (total_seats <= 0)
                throw new ArgumentException("total_seats должно быть больше 0", nameof(totalSeats));
            this.id = id;
            this.name = name;
            this.total_seats = totalSeats;
        }
    }

    public class EventRequest
    {
        public string name { get; set; }
        public int total_seats { get; set; }

        public EventRequest(string name, int totalSeats)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            }
            if (name.Length < 1)
            {
                throw new ArgumentException("Имя должно содержать минимум один символ", nameof(name));
            }
            if (totalSeats <= 0)
            {
                throw new ArgumentException("total_seats должно быть больше 0", nameof(totalSeats));
            }

            this.name = name;
            this.total_seats = totalSeats;
        }
    }
}