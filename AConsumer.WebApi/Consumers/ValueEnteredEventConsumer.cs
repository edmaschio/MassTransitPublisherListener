using MassTransit;
using MassTransitPublisherListener.Shared.EventContracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AConsumer.WebApi.Consumers
{
    public class ValueEnteredEventConsumer : IConsumer<ValueEntered>
    {
        private readonly ILogger<ValueEnteredEventConsumer> _logger;

        public ValueEnteredEventConsumer(ILogger<ValueEnteredEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ValueEntered> context)
        {
            await Task.Run(() => _logger.LogInformation("Another consumed value: {Value}", context.Message.Value));
        }
    }
}
