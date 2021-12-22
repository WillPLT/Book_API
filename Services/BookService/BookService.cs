using Book_API.Models;

namespace Book_API.Services.BookService
{
    public class BookService : IBookService
    {

        private static List<Book> books = new List<Book> {
            new Book(),
            new Book{Id=1,Title="World Wars" },


        };
        async Task<ServiceResponse<List<Book>>> IBookService.AddNewBook(Book newBook)
        {
            var serviceResponse=new ServiceResponse<List<Book>>();  
            books.Add(newBook);
            serviceResponse.Data = books;
            return serviceResponse;
        }

        async Task<ServiceResponse<List<Book>>> IBookService.GetAllBooks()
        {

            var serviceResponse = new ServiceResponse<List<Book>>();
            serviceResponse.Data = books;
            return serviceResponse;
        }

        async Task<ServiceResponse<Book>> IBookService.GetBookById(int id)
        {
            var serviceResponse = new ServiceResponse<Book>();
            serviceResponse.Data= books.FirstOrDefault(c => c.Id == id);
            return serviceResponse;
        }
    }
}
