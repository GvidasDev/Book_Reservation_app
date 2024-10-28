namespace Book_Reservation_app.Models {
    public class Reservation {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Days { get; set; }
        public bool IsQuickPickUp { get; set; }
        public bool IsAudioBook { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReservationEnd { get; set; }

        public Reservation() { }
        public Reservation(int bookId, int days, bool isQuickPickUp, bool isAudioBook, decimal price, DateTime resEnd) {
            BookId = bookId; 
            Days = days; 
            IsQuickPickUp = isQuickPickUp; 
            IsAudioBook = isAudioBook;
            TotalPrice = price; 
            ReservationEnd = resEnd;
        }
    }

    public class ReservationC {
        public int BookId { get; set; }
        public bool IsAudioBook { get; set; }
        public bool IsQuickPickUp { get; set; }
        public DateTime ReservationEnd { get; set; }
    }

    public class ReservationWithBook {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Days { get; set; }
        public bool IsQuickPickUp { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReservationEnd { get; set; }
        public string Title { get; set; }
        public bool IsAudioBook { get; set; }
    }
}
