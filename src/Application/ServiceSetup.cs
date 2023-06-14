using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Vilnius1.Application.Database;
using System.Reflection;

namespace Vilnius1.Application;

public static class ServiceSetup
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("database");
        var dbPath = connectionString.Replace("Data Source=", string.Empty);
        connectionString = File.Exists(dbPath) 
            ? connectionString
            : connectionString.Replace($"Data Source={dbPath}", $"Data Source={Path.GetFullPath(Path.Join(AppContext.BaseDirectory, dbPath))}");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}

