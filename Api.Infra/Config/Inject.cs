using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.Config
{
    public static class Inject
    {
        private static IServiceProvider _kernel = null;
        public static void SetKernel(IServiceProvider kernel)
        {
            _kernel = kernel;
        }
        public static object Load(Type type)
        {
            return _kernel.GetService(type);
        }
        public static T Load<T>()
        {
            return (T)_kernel.GetService(typeof(T));
        }
    }
}
