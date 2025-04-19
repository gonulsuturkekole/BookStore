
using WebApi.Impl.Services;

public class FakeBookService : IBookService
{
    private readonly List<BookResponseModel> _books = new()
    {
        new BookResponseModel { Id = 1, Title = "katil", PageCount = 200, GenreId = 1, PublishDate = "2020-01-01" },
        new BookResponseModel { Id = 2, Title = "ölü gelin ", PageCount = 200, GenreId = 2, PublishDate = "2021-06-01" },
        new BookResponseModel { Id = 3, Title = "çiftçi", PageCount = 500, GenreId = 1, PublishDate = "2020-02-01" },
    };

    public List<BookResponseModel> GetAllBooks()
    {
        return _books;
    }

    public BookResponseModel GetBookById(int id)
    {
        return _books.FirstOrDefault(book => book.Id == id);
    }
}
