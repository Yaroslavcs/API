using AutoMapper;
using LibraryApi.BLL.DTOs;
using LibraryApi.BLL.Exceptions;
using LibraryApi.DAL.Entities;
using LibraryApi.DAL.Persistence;

namespace LibraryApi.BLL.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookDto> CreateAsync(CreateBookDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Book>(dto);
        await _unitOfWork.Books.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<BookDto>(entity);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id, cancellationToken);
        if (book is null)
            throw new NotFoundException("Книгу не знайдено");
        _unitOfWork.Books.Delete(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<BookDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.Books.GetAllAsync(cancellationToken);
        return list.Select(x => _mapper.Map<BookDto>(x)).ToList();
    }

    public async Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id, cancellationToken);
        return book is null ? null : _mapper.Map<BookDto>(book);
    }
}
