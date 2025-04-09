using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddController
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{

                Id = 1,
                Title = "Test",
                GenreId = 1,
                PageCount = 100,
                PublishDate = new DateTime(2001,12,12)
            },
            new Book{

                Id = 2,
                Title = "Test1",
                GenreId = 2,
                PageCount = 152,
                PublishDate = new DateTime(2001,06,18)
            },
            new Book{

                Id = 3,
                Title = "Test3",
                GenreId = 1,
                PageCount = 150,
                PublishDate = new DateTime(2001,02,12)
            },

        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
                return BadRequest();

            BookList.Add(newBook);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Book book)
        {
            var newBook = BookList.SingleOrDefault(x => x.Id == id);

            if (newBook == null)
            {
                return BadRequest(); 
            }
            newBook.Title = book.Title;
            newBook.GenreId = book.GenreId;
            newBook.PageCount = book.PageCount;
            newBook.PublishDate = book.PublishDate;

            return Ok(newBook);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book == null)
            {
                return BadRequest(); 
            }

            BookList.Remove(book); 
            return NoContent(); 
        }


    }
}