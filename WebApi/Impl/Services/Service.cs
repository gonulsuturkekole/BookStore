namespace WebApi.Impl.Services
{
    public interface IBookService
    {
        List<BookResponseModel> GetAllBooks();
        BookResponseModel GetBookById(int id);

    }
}
