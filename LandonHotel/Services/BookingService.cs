using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        //private readonly IBookingsRepository _bookingsRepository;
        private readonly IRoomsRepository _roomsRepository;

        public BookingService(IRoomsRepository roomsRepository)
        {
            //_bookingsRepository = bookingsRepository;
            _roomsRepository = roomsRepository;
        }

        public bool IsBookingValid(int roomId, Booking booking)
        {
            var guestIsSmoking = booking.IsSmoking;
            var guestIsBringingPets = booking.HasPets;
            var numberOfGuests = booking.NumberOfGuests;

            if (guestIsSmoking)
            {
                return false;
            }

            var room = _roomsRepository.GetRoom(roomId);

            if (guestIsBringingPets && !room.ArePetsAllowed)
            {
                return false;
            }

            if (numberOfGuests > room.Capacity)
            {
                return false;
            }

            return true;
        }
    }
}
