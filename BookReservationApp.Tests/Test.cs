using Book_Reservation_app;
using Book_Reservation_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationApp.Tests {
    public class Test {

        [Fact]
        public void FeeSum_5days_and_audioBook() {

            ReservationC reservation = new ReservationC {
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

            ReservationC reservation = new ReservationC {
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
