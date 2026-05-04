using LibraryApi.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.DAL;

public static class DalServiceCollectionExtensions
{
    public static IServiceCollection AddLibraryDal(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection AddLibraryDalInMemory(this IServiceCollection services, string? databaseName = null)
    {
        var name = databaseName ?? Guid.NewGuid().ToString();
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(name));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
