namespace Book_Reservation_app.Models {
    public class ReservationCreateModel {
        public int BookId { get; set; }
        public bool IsAudioBook { get; set; }
        public bool IsQuickPickUp { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
