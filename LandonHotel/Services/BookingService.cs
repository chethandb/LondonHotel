using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomsRepository _roomsRepository;

        public BookingService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public int CalculateBookingCost(int roomId, Booking booking)
        {
            return 0;
        }
    }
}
