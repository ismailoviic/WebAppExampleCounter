using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebAppExampleCounter.Services.IService;

namespace WebAppExampleCounter.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UsePostgreSql(this IServiceCollection services,
            IConfigurationSection configuration)
            => services
                .Configure<PostgreSqlConfiguration>(configuration)
                .AddTransient(x => x.GetService<IOptions<PostgreSqlConfiguration>>().Value)
                .AddTransient<ICounterService, CounterService>();
    }
}