using BookAPI.Models;
using BookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.Get(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.Get(id);
            if (book != null)
            {
                await _bookRepository.Delete(id);
                //return Ok(book);
                return NoContent();
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> PutBook([FromBody] Book book)
        {
            //var bookResult = await _bookRepository.Get(book.Id);
            //if (bookResult != null)
            //{
                await _bookRepository.Update(book);
                return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
                //return Ok(book);
            //}
            //return BadRequest();

        }

    }
}
