using WebApi.DBOperations;
using WebApi.Domain;
using WebApi.Impl.Model;

namespace WebApi.Impl.Command
{
   
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten var");
            book = new Book();
            book.Title = Model.Title;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;
             
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
    }
}
