using AutoMapper;
using LibraryApi.BLL.DTOs;
using LibraryApi.DAL.Entities;

namespace LibraryApi.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>().ForMember(d => d.Id, o => o.Ignore());
    }
}
