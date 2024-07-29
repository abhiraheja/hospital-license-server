using LicenseServer.Application.Interfaces;
using LicenseServer.Infrastructure.Repositories;
using LicenseServer.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServer.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            return services;
        }
    }
}
