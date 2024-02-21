using Core.Interfaces;
using Core.Interfaces.Repository;
using Core.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using WorkManagerWebApi.Extensions;
using Serilog;
using WorkManagerWebApi.Middleware;

namespace WorkManagerWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureLoggerService(builder.Configuration);
            builder.Services.ConfigureNpgsqlContext(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
