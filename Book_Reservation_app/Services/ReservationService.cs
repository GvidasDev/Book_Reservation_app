using Book_Reservation_app.Calculations;
using Book_Reservation_app.Data;
using Book_Reservation_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Reservation_app.Services {
    public class ReservationService {
        private readonly LibraryContext context;

        public ReservationService(LibraryContext context) {
            this.context = context;
        }

        public async Task<List<ReservationWithBook>> GetReservationsWithBooksAsync() {
            return await (from reservation in context.Reservations
                          join book in context.Books on reservation.BookId equals book.Id
                          select new ReservationWithBook {
                              Id = reservation.Id,
                              BookId = reservation.BookId,
                              Days = reservation.Days,
                              IsQuickPickUp = reservation.IsQuickPickUp,
                              TotalPrice = reservation.TotalPrice,
                              ReservationEnd = reservation.ReservationEnd,
                              IsAudioBook = reservation.IsAudioBook,
                              Title = book.Title
                          })
                          .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsAsync() {
            return await context.Reservations.ToListAsync();
        }

#nullable disable

        public async Task<Reservation> GetReservationByIdAsync(int id) {
            return await context.Reservations.FindAsync(id);
        }

#nullable restore

        public async Task<Reservation> CreateReservationAsync(ReservationCreateModel reservationc) {
            int days = 0;
            decimal totalPrice = 0;
            FeesCalculations.FeesSum(reservationc, ref days, ref totalPrice);

            var reservation = new Reservation(
                reservationc.BookId,
                days,
                reservationc.IsQuickPickUp,
                reservationc.IsAudioBook,
                totalPrice,
                reservationc.ReservationEnd
            );

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();
            return reservation;
        }

        public async Task<bool> UpdateReservationAsync(int id, Reservation reservation) {
            if (id != reservation.Id) return false;

            context.Entry(reservation).State = EntityState.Modified;
            try {
                await context.SaveChangesAsync();
                return true;
            } catch (DbUpdateConcurrencyException) {
                if (!await ReservationExistsAsync(id)) {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteReservationAsync(int id) {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation == null) return false;

            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> ReservationExistsAsync(int id) {
            return await context.Reservations.AnyAsync(e => e.Id == id);
        }
    }
}
