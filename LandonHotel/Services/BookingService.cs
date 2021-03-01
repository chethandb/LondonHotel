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

        public decimal CalculateBookingPrice(Booking booking)
        {
            var roomRepo = new RoomsRepository();
            var room = roomRepo.GetRoom(booking.RoomId);

            var numberOfNights = (booking.CheckOutDate - booking.CheckInDate).Days;
            return room.Rate * numberOfNights;
        }
    }
}
