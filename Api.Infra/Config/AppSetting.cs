using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.Config
{
    public class AppSetting
    {
        private static IConfiguration _configuration = null;
        public static void SetConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string GetSection(string name)
        {
            return _configuration[name];
        }
    }
}
