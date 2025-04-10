namespace BookStore.Api.Controllers
{
    internal class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreEnum Genre { get; set; }
    }

    public enum GenreEnum
    {
        PersonalGrowth = 1,
        Noval = 2,

    }
}