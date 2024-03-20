using SQLitePCL;

namespace Mission11Graham.Models;

public class EFBookRepository : IBookInterface
{
    private BookstoreContext _context;
    
    public EFBookRepository(BookstoreContext temp)
    {
        _context = temp;
    }
    
    public IQueryable<Book> Books => _context.Books;
}

