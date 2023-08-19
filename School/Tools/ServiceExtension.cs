using Application.IServices;
using Application.Services;
using Domain.IRepositories;
using Infrastructure;
using Persistence;

namespace School.api.Tools;

public static class ServiceExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IDbContext, ADOContext>();
    }
}
