using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebAppExampleCounter.Entities;
using WebAppExampleCounter.Services.IService;
using System.Threading.Tasks;

namespace SofPS4App.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CountersController : ControllerBase
    {
        private readonly ILogger<CountersController> _logger;
        private readonly ICounterService _counter;
        public CountersController(ILogger<CountersController> logger, ICounterService counter)
        {
            _logger = logger;
            _counter = counter;
        }

        [AllowAnonymous]
        [HttpGet("getValue/{counterId}")]
        public async Task<int> GetCounterValue([FromRoute] Guid counterId) => await _counter.GetCounterValue(counterId);

        [AllowAnonymous]
        [HttpPost("setValue")]
        public void SetCounterValue([FromQuery(Name = "counterId")] Guid counterId, [FromQuery(Name = "Value")] int counterValue)
            => _counter.SetCounterValueAsync(new Counter() { CounterId = counterId, Value = counterValue });

    }
}
