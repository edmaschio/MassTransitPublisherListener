using MassTransit;
using MassTransitPublisherListener.EventContracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitPublisherListener.Consumers
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
            await Task.Run(() => _logger.LogInformation("Consumed value: {Value}", context.Message.Value));
        }
    }
}
