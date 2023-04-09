using Contracts;
using Repositories;

namespace LoadValidateAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRespositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
