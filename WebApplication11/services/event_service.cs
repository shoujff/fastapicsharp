using Microsoft.AspNetCore.Http;
using HTTPException;
using EventModels;
namespace HTTPException
{
    public class HttpException : Exception
    {
        public int status_code { get; set; }
        public string detail { get; set; }

        public HttpException(int status_code, string detail)
        {
            this.status_code = status_code;
            this.detail = detail;
        }
    }
}
                    
class EventService
{
    private readonly EventRepository eventRepo;
    public EventService()
    {
        eventRepo = new EventRepository();
    }
    public async Task<EventModel> Create_Event(string name, int total_seats)
    {
        try
        {
            var newevent = await eventRepo.CreateAsync(name, total_seats);
            return newevent;
        } catch (InvalidOperationException)
        {
            throw new HttpException(StatusCodes.Status400BadRequest, "Event with this name already exists");
        }
                           
        
    }
}