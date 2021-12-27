using Book_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Dtos.Book
{
    public class GetBookDto
    {
        public string Book_code { get; set; }

        public string Title { get; set; } = "Bible of the Fallen";

        public string Description { get; set; } = "Fiction";

        public string Author { get; set; } = "Anonymous";
        public string Brand { get; set; } = "Acme";

        public int year { get; set; }

        public GenreBookClass Class { get; set; } = GenreBookClass.SciFi;

        [Column(TypeName = "decimal(5,2)")]
        public decimal price { get; set; }
    }
}
