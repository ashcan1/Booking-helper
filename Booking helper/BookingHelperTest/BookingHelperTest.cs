using Booking_helper.BookingHelper;
using Moq;
using NUnit.Framework;

namespace Booking_helper.BookingHelperTest
{
    [TestFixture]
    public class BookingHelperTest
    {
        [Test]

        public void OverlappingBookingExist_BookingStartAndFinishesBeforeAnExistingBooking()
        {
            var repository = new Mock<IBookrepository>();

            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id =2,
                    ArrivalDate =  new DateTime(2017,1,15, 14,0 ,0),
                    DepartureDate = new DateTime (2017,1,20, 10,0,0),
                    Reference = "a"
                    
                }

            }.AsQueryable());

            BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
            }, repository.Object);






        }

    }
}
