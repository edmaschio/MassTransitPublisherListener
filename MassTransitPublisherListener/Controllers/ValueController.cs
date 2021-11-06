using MassTransit;
using MassTransitPublisherListener.Shared.EventContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MassTransitPublisherListener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {

        private readonly ILogger<ValueController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public ValueController(ILogger<ValueController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(string value, CancellationToken ct)
        {
            await _publishEndpoint.Publish<ValueEntered>(new { Value = value, Test = 1 }, ct);

            _logger.LogInformation($"Published value: {value}");

            return Ok();
        }
    }
}
