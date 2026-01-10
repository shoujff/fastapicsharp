using HTTPException;
using BookingModels;
    public class BookingService
    {
    private readonly BookingRepository bookingRepo;
    private readonly EventRepository eventRepo;

    public async Task<Booking> Reserve(int eventid, string user_id)
    {

        try
        {
            var ev = await eventRepo.get_by_id(eventid);
            if (ev == null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "Мероприятие не найдено");
            }
            var bookings_count = await bookingRepo.count_by_event(eventid);
            if (bookings_count >= ev.total_seats)
            {
                throw new HttpException(StatusCodes.Status409Conflict, "Нет свободных мест");
            }
            var booking = await bookingRepo.create(user_id, eventid);
           
            return booking;
        }
       
        catch (HttpException)
        {
            throw new HttpException(StatusCodes.Status409Conflict, "Пользователь уже забронирован");

        }
    }
    }


