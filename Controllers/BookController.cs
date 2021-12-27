using Book_API.Dtos.Book;
using Book_API.Models;
using Book_API.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Validation;

namespace Book_API.Controllers
{

    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> GetCollection()
        {
            return Ok(await _bookService.GetAllBooks());

        }

        [HttpGet("{bookCode}")]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> GetBook(string bookCode)
        {
            return Ok(await _bookService.GetBookById(bookCode));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> AddBook(AddBookDto newBook)
        {
            try
            {
                var response = await _bookService.AddNewBook(newBook);

                return this.StatusCode(StatusCodes.Status201Created, response);
                //return Ok(await _bookService.AddNewBook(newBook));
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return BadRequest(error);

            }



        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> UpdateBook(UpdatedBookDto updateBook)
        {
            var response = await _bookService.UpdateBook(updateBook);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok("Data was updated sucessfully!");
        }

        [HttpDelete("{bookCode}")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> DeleteBook(string bookCode)
        {
            var response = await _bookService.DeleteBook(bookCode);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok("Data was deleted sucessfully!");
        }

        [HttpDelete("RemoveAll")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> DeleteBookCollection()
        {
            var response = await _bookService.DeleteBookCollection();

            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }


    }
}
