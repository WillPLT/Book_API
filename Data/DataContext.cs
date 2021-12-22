using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
