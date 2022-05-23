using Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.Data.DapperResolver
{
    public class CustomColumnNameResolver : IColumnNameResolver
    {
        public string ResolveColumnName(PropertyInfo propertyInfo)
        {
            return $@"{propertyInfo.Name}";
        }
    }

}
