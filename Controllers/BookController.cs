using Book_API.Dtos.Book;
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
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> Get()
        {
            return Ok( await _bookService.GetAllBooks());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> GetBook(int id)
        {
            return Ok( await _bookService.GetBookById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> AddBook(AddBookDto newBook)
        { 
            return Ok(await _bookService.AddNewBook(newBook));

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> UpdateBook(UpdatedBookDto updateBook) 
        {
            var response = await _bookService.UpdateBook(updateBook);
            if (response.Data==null)
            {
                return NotFound(response);
            }

            return Ok("Data was updated sucessfully!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok("Data was deleted sucessfully!");
        }


    }
}
