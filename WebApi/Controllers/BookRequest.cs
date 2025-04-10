using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Controllers
{
    public class BookRequest
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }


    }
}