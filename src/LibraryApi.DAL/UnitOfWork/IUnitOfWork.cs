using LibraryApi.DAL.Repositories;

namespace LibraryApi.DAL.Persistence;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
