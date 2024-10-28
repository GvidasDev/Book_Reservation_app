using Book_Reservation_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Reservation_app.Data {
    public class LibraryContext : DbContext {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
