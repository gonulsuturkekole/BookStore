using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi;
using WebApi.Impl.Query;
using WebApi.Impl.Command;
using WebApi.Impl.Model;
using AutoMapper;
using MediatR;



namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
                
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookResponseModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = _mapper.Map<CreateBookModel>(newBook); // ?? Mapping burada!
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }




        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    var entity = new Book
        //    {
        //        Title = request.Title,
        //    };

        //    _context.Books.Add(entity);
        //    _context.SaveChanges();

        //    var response = new BookResponse { Id = entity.Id, Title = entity.Title };
        //    return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] BookRequest request)
        //{
        //    var book = _context.Books.Find(id);
        //    if (book == null) return NotFound(new { message = "Book not found." });

        //    book.Title = request.Title;


        //    _context.SaveChanges();

        //    return Ok(new BookResponse { Id = book.Id, Title = book.Title });
        //}

        //[HttpPatch("{id}")]
        //public IActionResult Patch(int id, [FromBody] JsonElement patchData)
        //{
        //    var book = _context.Books.Find(id);
        //    if (book == null) return NotFound(new { message = "Book not found." });

        //    if (patchData.TryGetProperty("title", out var title))
        //        book.Title = title.GetString();

        //    _context.SaveChanges();

        //    return Ok(new BookResponse { Id = book.Id, Title = book.Title });
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var book = _context.Books.Find(id);
        //    if (book == null) return NotFound(new { message = "Book not found." });

        //    _context.Books.Remove(book);
        //    _context.SaveChanges();

        //    return NoContent();
        //}


    }
     }
