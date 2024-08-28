using Application.AutoMapper;
using Application.Interfaces;
using Application.Services;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddDbContext<GliceControlContext>(opt =>
        {
            opt.UseSqlite("Data Source=GliceControl");
        });

        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<IControleGlicemicoRepository, ControleGlicemicoRepository>();
        services.AddScoped<IControleGlicemicoService, ControleGlicemicoService>();

        return services;
    }
}