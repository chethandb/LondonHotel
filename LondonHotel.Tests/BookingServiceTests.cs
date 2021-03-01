using LandonHotel.Services;
using System;
using Xunit;

namespace LondonHotel.Tests
{
    public class BookingServiceTests
    {
        [Fact]
        public void IsBookingValid_NonSmoker_Valid()
        {
            var service = new BookingService(null, null);
            var isValid = service.IsBookingValid(1, new LandonHotel.Data.Booking()
            {
                IsSmoking = false
            });

            Assert.True(isValid);

        }

        [Fact]
        public void IsBookingValid_Smoker_InValid()
        {
            var service = new BookingService(null, null);
            var isValid = service.IsBookingValid(1, new LandonHotel.Data.Booking()
            {
                IsSmoking = true
            });

            Assert.False(isValid);

        }
    }
}
