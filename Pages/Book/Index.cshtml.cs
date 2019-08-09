using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using booksmart.Models;

namespace booksmart.Pages_Book
{
    public class IndexModel : PageModel
    {
        private readonly booksmart.Models.BookSmartBookContext _context;

        public IndexModel(booksmart.Models.BookSmartBookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
