using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain
{

    namespace BookStore.Configurations
    {
        public class BookConfiguration : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id).UseIdentityColumn();

                builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

                builder.Property(x => x.PageCount).IsRequired();

                builder.Property(x => x.PublishDate).IsRequired();

                builder.Property(x => x.GenreId).IsRequired();

            }
        }
    }
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
