using FruteriaAPI.Business.Services;
using FruteriaAPI.Data.Repositories;

namespace FruteriaAPI.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IFrutaRepository, FrutaRepository>();
            services.AddTransient<IFrutaService, FrutaService>();
        }
    }
}
