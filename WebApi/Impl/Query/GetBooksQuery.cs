using System.Globalization;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Domain;

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
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookResponseModel> vm = new List<BookResponseModel>();
            foreach (var book in bookList) 
            {
                vm.Add(new BookResponseModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount,
                });
            }
            return vm;
        }

    }
}
