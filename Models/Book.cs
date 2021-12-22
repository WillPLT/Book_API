namespace Book_API.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = "Bible of the Fallen";

        public string Description { get; set; } = "Fiction";

        public string Author { get; set; } = "Anonymous";
        public string Brand { get; set; } = "Acme";

        public int year { get; set; }

        public GenreBookClass Class { get; set; } = GenreBookClass.SciFi;

        public decimal price { get; set; }
    }
}
