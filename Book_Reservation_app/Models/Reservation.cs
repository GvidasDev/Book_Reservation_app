namespace Book_Reservation_app.Models {
    public class Reservation {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Days { get; set; }
        public bool IsQuickPickUp { get; set; }
        public bool IsAudioBook { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReservationEnd { get; set; }

        //without empty constructor, data from database won't load
        protected Reservation() { }

        public Reservation(int bookId, int days, bool isQuickPickUp, bool isAudioBook, decimal price, DateTime reservationEndDate) {
            BookId = bookId; 
            Days = days; 
            IsQuickPickUp = isQuickPickUp; 
            IsAudioBook = isAudioBook;
            TotalPrice = price; 
            ReservationEnd = reservationEndDate;
        }
    }
}
