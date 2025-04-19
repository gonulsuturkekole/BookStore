using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Impl.Query
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailResponseModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);

            if (book == null)
                throw new InvalidOperationException($" {BookId} book not found");

            var vm = new BookDetailResponseModel
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                Genre = ((GenreEnum)book.GenreId).ToString()
            };

            return vm;
        }

    }

}
