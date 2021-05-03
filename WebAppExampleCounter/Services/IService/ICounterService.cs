using System;
using System.Threading.Tasks;
using WebAppExampleCounter.Entities;

namespace WebAppExampleCounter.Services.IService
{
    public interface ICounterService
    {
        public Task<int> GetCounterValue(Guid counterId);

        public void SetCounterValueAsync(Counter counter);
    }
}
