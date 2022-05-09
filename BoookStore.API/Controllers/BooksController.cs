using BoookStore.API.Models;
using BoookStore.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllBooks()
        {
            var books =await _bookRepository.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel Book)
        {
            var id = await _bookRepository.AddBookByAsync(Book);
            return CreatedAtAction(nameof(GetBookById), new {id=id,controller="books"},id );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int BookId, [FromBody] BookModel NewBook)
        {
            await _bookRepository.UpdateBookByAsync(BookId, NewBook);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookByAsync(id);
            return Ok();
        }

    }
}
