using Api.Core.Interfaces;
using Api.Infra.Service;
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
            services.AddSingleton(typeof(IRepository<>), typeof(Infra.Data.Repository<>));
            services.AddSingleton<IProdutoService, ProdutoService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        public static void SetConfigInfra(this IServiceCollection services, IConfiguration configuration)
        {
            Infra.Config.AppSetting.SetConfig(configuration);
            Infra.Config.Inject.SetKernel(services.BuildServiceProvider());
        }
    }
}
