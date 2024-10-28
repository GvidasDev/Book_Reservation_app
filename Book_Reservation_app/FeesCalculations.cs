using Book_Reservation_app.Models;

namespace Book_Reservation_app {
    public static class FeesCalculations {
        public static void FeesSum(ReservationC reservationc, ref int days, ref decimal totalPrice) {
            days = CalculatedDays(reservationc);
            decimal price = SetReservationFee(reservationc, days);
            totalPrice = Discount(price, days);
            totalPrice += SetServiceFee();
            totalPrice += SetPickUpFee(reservationc);
        }

        static int CalculatedDays(ReservationC reservationc) {
            DateTime currentDate = DateTime.Now;
            DateTime resPeriodDate = reservationc.ReservationEnd;
            TimeSpan differenceDays = resPeriodDate - currentDate;
            int days = (int)differenceDays.TotalDays + 1;
            return days;
        }

        static decimal Discount(decimal price, int days) {
            if (days > 3) {
                if (days > 10) {
                    price *= 0.8m;
                }
                price *= 0.9m;
            }
            return price;
        }

        static decimal SetReservationFee(ReservationC reservationc, int days) {
            return reservationc.IsAudioBook ? 3 * days : 2 * days;
        }

        static decimal SetPickUpFee(ReservationC reservationc) {
            return reservationc.IsQuickPickUp ? 5 : 0;
        }

        static decimal SetServiceFee() {
            return 3;
        }
    }
}
