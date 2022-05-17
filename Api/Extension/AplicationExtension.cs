using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extension
{
    public static class AplicationExtension
    {
        public static IServiceCollection GetAppServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(Core.Interfaces.IRepository<>), typeof(Infra.Data.Repository<>));
            return services;
        }
        public static void SetConfigInfra(this IServiceCollection services, IConfiguration configuration)
        {
            Infra.Config.AppSetting.SetConfig(configuration);
            Infra.Config.Inject.SetKernel(services.BuildServiceProvider());
        }
    }
}
