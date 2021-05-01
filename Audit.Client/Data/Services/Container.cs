using Audit.Client.Data.Repositories;
using Audit.Client.Data.Services.AuditDomain;
using Audit.Client.Data.Services.DifferenceTwoObjectsDomain;
using Audit.Client.Data.Services.LogChangesBettwenTwoEntityDomain;
using Audit.Client.Data.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Audit.Client.Data.Services
{
    public static class Container
    {
        public static IServiceCollection AddAuditServices(this IServiceCollection services, Action<DbSettings> configureOptions)
        {

            DbSettings options = new();
            configureOptions(options);
            services.AddSingleton(options);

            services.AddSingleton<IRepository, Repository>();

            services.AddTransient<IInsertAuditService, InsertAuditService>();
            services.AddTransient<IGetDifferenceObjectService, GetDifferenceObjectService>();
            services.AddTransient<ILogChangesBettwenTwoEntity, LogChangesBettwenTwoEntity>();

            return services;
        }
    }
}
