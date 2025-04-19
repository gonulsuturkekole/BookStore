using System.ComponentModel.DataAnnotations;
using WebApi.Base;

namespace WebApi.Impl.Model
{
    public class CreateBookModel : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId {  get; set; }
       public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }
}
public class BookResponseModel : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "The number of pages must be at least 1.")]
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    [Required(ErrorMessage = "ID required")]
    public string Genre{ get; set; }
    public int Id { get; internal set; }
    public int GenreId { get; internal set; }
}

public class BookDetailResponseModel : BaseEntity
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string Genre { get; set; }
    public string PublishDate { get; set; }
}

public class UpdateBookModel : BaseEntity
{
    public string Title { get; set; }
    public int GenreId{ get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

}