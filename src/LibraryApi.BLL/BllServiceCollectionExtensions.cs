using FluentValidation;
using LibraryApi.BLL.DTOs;
using LibraryApi.BLL.Mapping;
using LibraryApi.BLL.Services;
using LibraryApi.BLL.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.BLL;

public static class BllServiceCollectionExtensions
{
    public static IServiceCollection AddLibraryBll(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>();
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}
