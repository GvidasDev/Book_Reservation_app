using Book_Reservation_app.Calculations;
using Book_Reservation_app.Models;

namespace BookReservationApp.Tests
{
    public class FeesCalculationsTests {

        [Fact]
        public void FeeSum_5days_and_audioBook() {

            ReservationCreateModel reservation = new ReservationCreateModel {
                IsQuickPickUp = false,
                IsAudioBook = true,
                ReservationEnd = DateTime.Now.AddDays(5)
            };

            int days = 0;
            decimal totalPrice = 0;

            FeesCalculations.FeesSum(reservation, ref days, ref totalPrice);

            Assert.Equal(5, days);
            Assert.Equal(16.5m, totalPrice);
        }

        [Fact]
        public void FeeSum_13days_and_Book_isquickPickup() {

            ReservationCreateModel reservation = new ReservationCreateModel {
                IsQuickPickUp = true,
                IsAudioBook = false,
                ReservationEnd = DateTime.Now.AddDays(13)
            };

            int days = 0;
            decimal totalPrice = 0;

            FeesCalculations.FeesSum(reservation, ref days, ref totalPrice);

            Assert.Equal(13, days);
            Assert.Equal(28.8m, totalPrice);
        }
    }
}
