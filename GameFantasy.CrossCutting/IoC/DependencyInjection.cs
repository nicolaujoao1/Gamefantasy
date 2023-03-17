using GameFantasy.Application.Interfaces;
using GameFantasy.Application.Mappings;
using GameFantasy.Application.Services;
using GameFantasy.Domain.Interfaces;
using GameFantasy.Infrastructure.Context;
using GameFantasy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GameFantasy.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            //), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
               , b => b.MigrationsAssembly("GameFantasy.API")));

            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IChampionShipService, ChampionShipService>();
            services.AddScoped<IChampionShipRepository, ChampionShipRepository>();
            services.AddScoped<ITimeScoreRepository, TimeScoreRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
