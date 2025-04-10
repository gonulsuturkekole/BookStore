using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? name, [FromQuery] string? sort)
        {
            var result = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                result = result.Where(x => x.Title.Contains(name));

            if (!string.IsNullOrWhiteSpace(sort) && sort == "title")
                result = result.OrderBy(x => x.Title);

            var books = result.Select(x => new BookResponse
            {
                Id = x.Id,
                Title = x.Title,
                
            }).ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound(new { message = "Book not found." });

            return Ok(new BookResponse { Id = book.Id, Title = book.Title });
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new Book
            {
                Title = request.Title,
               
            };

            _context.Books.Add(entity);
            _context.SaveChanges();

            var response = new BookResponse { Id = entity.Id, Title = entity.Title };
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookRequest request)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound(new { message = "Book not found." });

            book.Title = request.Title;
            

            _context.SaveChanges();

            return Ok(new BookResponse { Id = book.Id, Title = book.Title });
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonElement patchData)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound(new { message = "Book not found." });

            if (patchData.TryGetProperty("title", out var title))
                book.Title = title.GetString();

            _context.SaveChanges();

            return Ok(new BookResponse { Id = book.Id, Title = book.Title });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound(new { message = "Book not found." });

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}