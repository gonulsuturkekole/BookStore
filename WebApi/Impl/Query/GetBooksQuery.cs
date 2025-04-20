using System.Globalization;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Domain;
using WebApi.Impl.Model;

namespace WebApi.Impl.Query
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookResponseModel> Handle()
        {
            var books = _dbContext.Books
                .OrderBy(x => x.Id)
                .Select(book => new BookResponseModel
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PageCount = book.PageCount
                })
                .ToList();

            return books;
        }
    }
}
