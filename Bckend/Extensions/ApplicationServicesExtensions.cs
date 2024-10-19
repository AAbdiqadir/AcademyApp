using Bckend.entities;
using Bckend.Interface;
using Bckend.Services;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Extensions;

public static class ApplicationServicesExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDataContext>(
            dbContextOptions => dbContextOptions
                .UseSqlite(connectionString)
            // The following three options help with debugging, but should
            // be changed or removed for production.
        );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
    
}