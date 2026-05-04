using LibraryApi.BLL.DTOs;

namespace LibraryApi.BLL.Services;

public interface IBookService
{
    Task<IReadOnlyList<BookDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<BookDto> CreateAsync(CreateBookDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
