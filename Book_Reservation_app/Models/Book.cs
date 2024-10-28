namespace Book_Reservation_app.Models {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Year { get; set; }
        public bool IsAudioBook { get; set; }
        public string Image { get; set; }
    }
}
