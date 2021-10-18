using MassTransit;
using MassTransitPublisherListener.EventContracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitPublisherListener.Consumers
{
    public class ValueEnteredAnotherEventConsumer : IConsumer<ValueEntered>
    {
        private readonly ILogger<ValueEnteredAnotherEventConsumer> _logger;

        public ValueEnteredAnotherEventConsumer(ILogger<ValueEnteredAnotherEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ValueEntered> context)
        {
            await Task.Run(() => _logger.LogInformation($"Another Consumed Value: {context.Message.Value}"));
        }
    }
}
