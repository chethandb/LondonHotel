using LandonHotel.Services;
using System;
using Xunit;

namespace LondonHotel.Tests
{
    public class BookingServiceTests
    {
        [Fact]
        public void Test1()
        {
            var service = new BookingService(null, null);
            var isValid = service.IsBookingValid(1, new LandonHotel.Data.Booking()
            {
                IsSmoking = false
            });

            Assert.True(isValid);

        }
    }
}
