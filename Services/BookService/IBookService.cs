using Book_API.Dtos.Book;
using Book_API.Models;

namespace Book_API.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<GetBookDto>>> GetAllBooks();
        Task<ServiceResponse<GetBookDto>> GetBookById(int id);

        Task<ServiceResponse<List<GetBookDto>>> AddNewBook(AddBookDto NewBook);

        Task<ServiceResponse<GetBookDto>> UpdateBook(UpdatedBookDto updatedBook);

        Task<ServiceResponse<List<GetBookDto>>> DeleteBook(int id);
    }
}
