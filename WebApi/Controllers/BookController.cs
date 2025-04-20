using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Impl.Query;
using WebApi.Impl.Command;
using WebApi.Impl.Model;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Impl.Services;
using FluentValidation;
using WebApi.Domain;


namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IValidator<CreateBookModel> _createBookValidator;

        public BooksController(BookStoreDbContext context, IMapper mapper, IBookService bookService, IValidator<CreateBookModel> createBookValidator)
        {
            _context = context;
            _mapper = mapper;
            _bookService = bookService;
            _createBookValidator = createBookValidator;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailResponseModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);


        }

        [HttpGet("list")]
        public IActionResult ListBooks([FromQuery] string name, [FromQuery] string sortBy = "title")
        {
            var books = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(b => b.Title.Contains(name));
            }

            if (sortBy == "date")
                books = books.OrderBy(b => b.PublishDate);
            else
                books = books.OrderBy(b => b.Title);

            return Ok(books.ToList());
        }

        [HttpGet("fake")]
        public IActionResult GetAllFromFakeService()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateBookModel model)
        {
            var result = _createBookValidator.Validate(model);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            try
            {
                var command = new CreateBookCommand(_context)
                {
                    Model = model
                };
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return BadRequest(result.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage }));

        }



        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
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
