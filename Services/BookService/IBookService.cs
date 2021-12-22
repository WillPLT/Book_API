using Book_API.Models;

namespace Book_API.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetAllBooks();
        Task<ServiceResponse<Book>> GetBookById(int id);

        Task<ServiceResponse<List<Book>>> AddNewBook(Book NewBook);
    }
}
