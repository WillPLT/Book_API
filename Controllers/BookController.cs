using Book_API.Models;
using Book_API.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }    

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> Get()
        {
            return Ok( await _bookService.GetAllBooks());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBook(int id)
        {
            return Ok( await _bookService.GetBookById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> AddBook(Book newBook)
        { 
            return Ok(await _bookService.AddNewBook(newBook));

        }


    }
}
