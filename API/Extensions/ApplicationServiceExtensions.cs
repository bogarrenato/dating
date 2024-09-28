using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    // Extend this
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        // Register our data context
        services.AddDbContext<DataContext>(options =>
        {
            // appsettings.development.json - bol olvassa ki
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        // AddScoped -  Created once by client request
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoService, PhotoService>();
        // Auto mapper registration
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Type safed cloudnaryis
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));


        return services;
    }
}
