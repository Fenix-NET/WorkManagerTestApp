using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace WorkManagerWebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureNpgsqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("DbConnection")));

    public static void ConfigureLoggerService(this IHostBuilder host, IConfiguration configuration) =>
        host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.File("logs/app-logs.txt"));

}