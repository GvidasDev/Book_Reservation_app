namespace Book_Reservation_app.Models {
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
