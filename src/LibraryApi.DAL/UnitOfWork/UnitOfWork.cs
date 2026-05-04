using LibraryApi.DAL.Repositories;

namespace LibraryApi.DAL.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBookRepository? _books;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IBookRepository Books => _books ??= new BookRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
