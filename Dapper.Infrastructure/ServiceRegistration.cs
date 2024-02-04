using Dapper.Application.Interfaces;
using Dapper.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IMeetingRepository, MeetingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReportsRepository, ReportsRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IUserBusienss, UserBusiness>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
