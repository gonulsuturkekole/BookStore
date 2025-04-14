namespace WebApi.Impl.Model
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId {  get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }



    }
}
public class BookResponseModel
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

    public string Genre { get; set; }
}

public class BookDetailResponseModel
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string Genre { get; set; }
    public string PublishDate { get; set; }
}

public class UpdateBookModel
{
    public string Title { get; set; }
    public int GenreId{ get; set; }
}