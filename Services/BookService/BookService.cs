using AutoMapper;
using Book_API.Data;
using Book_API.Dtos.Book;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services.BookService
{
    public class BookService : IBookService
    {

        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public BookService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;   
        }
       public async Task<ServiceResponse<List<GetBookDto>>> AddNewBook(AddBookDto newBook)
        {
            
            var serviceResponse=new ServiceResponse<List<GetBookDto>>();  
            Book book=_mapper.Map<Book>(newBook);
           _context.Books.Add(book);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Books.Select(c=>_mapper.Map<GetBookDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookDto>>> DeleteBook(string bookCode)
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            try
            {
                Book book = await _context.Books.FirstAsync(c => c.Book_code == bookCode);

                _context.Books.Remove(book);

                await _context.SaveChangesAsync();

                serviceResponse.Data =  _context.Books.Select(c=>_mapper.Map<GetBookDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.sucesss = false;
                serviceResponse.message = ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookDto>>> DeleteBookCollection()
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            
           
            
                serviceResponse.sucesss = false;
                serviceResponse.message = "405 Method not allowed!";
            


            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooks()
        {

            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            var dbBooks = await _context.Books.ToListAsync();
            serviceResponse.Data = dbBooks.Select(c => _mapper.Map<GetBookDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> GetBookById(string bookCode)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            var dbBook = await _context.Books.FirstOrDefaultAsync(c => c.Book_code == bookCode);
            serviceResponse.Data= _mapper.Map<GetBookDto>(dbBook);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> UpdateBook( string bookcode, UpdatedBookDto updatedBook)
        {
            var serviceResponse= new ServiceResponse<GetBookDto>();
            try
            {
                Book book = await _context.Books.FirstOrDefaultAsync(c => c.Book_code == bookcode);

                book.Author = updatedBook.Author;
                book.Title = updatedBook.Title;
                book.Description = updatedBook.Description;
                book.Brand = updatedBook.Brand;
                book.year = updatedBook.year;
                book.Class = updatedBook.Genre;
                book.price = updatedBook.price;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetBookDto>(book);
            }
            catch (Exception ex)
            {
                serviceResponse.sucesss = false;
                serviceResponse.message = "Data not found!!";
            }
            

            return serviceResponse;


        }
    }
}
