using LibraryApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.DAL.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Book?> FindByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Title == title, cancellationToken);
    }
}
