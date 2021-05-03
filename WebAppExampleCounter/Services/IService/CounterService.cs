using System;
using System.Threading.Tasks;
using WebAppExampleCounter.Entities;
using WebAppExampleCounter.Core;

namespace WebAppExampleCounter.Services.IService
{
    public class CounterService : AbstractPostgreSqlRepository, ICounterService
    {
        public CounterService(PostgreSqlConfiguration postgreSqlConfiguration) : base(postgreSqlConfiguration)
        {

        }

        public async Task<int> GetCounterValue(Guid counterId) => await QueryFirstAsync<int>(
            $@"SELECT countervalue FROM public.counters  WHERE  counterid= '{counterId}';");


        public async void SetCounterValueAsync(Counter counter)
        {
            var sql = "UPDATE public.counters SET countervalue = (@vallue) WHERE counterid=(@idd);";
            ExecuteSql(sql, new { vallue = counter.Value, idd = counter.CounterId });
        }
    }
}
