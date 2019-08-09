using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;


namespace booksmart.Models
{
    public class BookSmartBookContext : DbContext
    {
        public BookSmartBookContext (DbContextOptions<BookSmartBookContext> options) 
            : base(options)
        {

        }

        public DbSet<booksmart.Models.Book> Book { get; set; }
    }
}