using LibraryApi.DAL.Entities;

namespace LibraryApi.DAL.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book?> FindByTitleAsync(string title, CancellationToken cancellationToken = default);
}
