using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.Interfaces;
using Services.ServicesP.ServicesM;
using Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ServicesP
{
    public static class ServicesExtensionMethod
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper();
           // services.AddRepositories(connectionString);

            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<UnitOfWorkk, UnitOfWorkk>();

            return services;
        }

        //private static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        //{
        //    services.ConfigDatabase(connectionString);
        //    services.ConfigRepositories();
        //    return services;
        //}
    }
}
