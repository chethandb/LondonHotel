using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        //private readonly IBookingsRepository _bookingsRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly ICouponRepository _couponRepo;

        public BookingService(IRoomsRepository roomsRepository,
                              ICouponRepository couponRepo)
        {
            //_bookingsRepository = bookingsRepository;
            _roomsRepository = roomsRepository;
            _couponRepo = couponRepo;
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
            var room = _roomsRepository.GetRoom(booking.RoomId);
            var numberOfNights = (booking.CheckOutDate - booking.CheckInDate).Days;
            decimal price = room.Rate * numberOfNights;

            if (booking.CouponCode != null)
            {
                var discount = _couponRepo.GetCoupon(booking.CouponCode).PercentageDiscount;
                price = price - (price * discount / 100);
            }

            return price;
        }
    }
}
