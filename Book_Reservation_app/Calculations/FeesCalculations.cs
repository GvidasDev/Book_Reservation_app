using Book_Reservation_app.Models;

namespace Book_Reservation_app.Calculations
{
    public static class FeesCalculations
    {
        public static void FeesSum(ReservationCreateModel reservationc, ref int days, ref decimal totalPrice)
        {
            days = CalculatedDays(reservationc);
            decimal price = SetReservationFee(reservationc, days);
            totalPrice = Discount(price, days);
            totalPrice += SetServiceFee();
            totalPrice += SetPickUpFee(reservationc);
        }

        static int CalculatedDays(ReservationCreateModel reservationc)
        {
            DateTime currentDate = DateTime.Now;
            DateTime resPeriodDate = reservationc.ReservationEnd;
            TimeSpan differenceDays = resPeriodDate - currentDate;
            int days = (int)differenceDays.TotalDays + 1;
            return days;
        }

        static decimal Discount(decimal price, int days)
        {
            int lowerDiscountNumberOfDays = 3;
            int higherDiscountNumberOfDays = 10;

            decimal threeDayDiscount = 0.8m;
            decimal tenDayDiscount = 0.8m;

            if (days > lowerDiscountNumberOfDays)
            {
                if (days > higherDiscountNumberOfDays)
                {
                    return price *= threeDayDiscount;
                }
                return price *= tenDayDiscount;
            }
            return price;
        }

        static decimal SetReservationFee(ReservationCreateModel reservationc, int days)
        {
            int priceForAudioBook = 3;
            int priceForBook = 2;
            return reservationc.IsAudioBook ? priceForAudioBook * days : priceForBook * days;
        }

        static decimal SetPickUpFee(ReservationCreateModel reservationc)
        {
            int priceForQuickPickUp = 5;
            return reservationc.IsQuickPickUp ? priceForQuickPickUp : 0;
        }

        static decimal SetServiceFee()
        {
            int serviceFee = 3;
            return serviceFee;
        }
    }
}
