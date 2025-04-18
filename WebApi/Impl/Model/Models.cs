using System.ComponentModel.DataAnnotations;

namespace WebApi.Impl.Model
{
    public class CreateBookModel
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Tür ID zorunludur.")]
        public int GenreId {  get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sayfa sayısı en az 1 olmalıdır.")]
        public int PageCount { get; set; }
        public string PublishDate { get; set; }



    }
}
public class BookResponseModel
{
    [Required(ErrorMessage = "Başlık zorunludur.")]
    public string Title { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Sayfa sayısı en az 1 olmalıdır.")]
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    [Required(ErrorMessage = "Tür ID zorunludur.")]
    public string Genre{ get; set; }
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
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

}