﻿using WebApi.DBOperations;

namespace WebApi.Impl.Command
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı:");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
