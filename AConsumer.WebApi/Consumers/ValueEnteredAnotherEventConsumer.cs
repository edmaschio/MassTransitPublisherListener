using MassTransit;
using MassTransitPublisherListener.Shared.EventContracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AConsumer.WebApi.Consumers
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
            await Task.Run(() => _logger.LogInformation("Another consumed value: {Value}", context.Message.Value));
        }
    }
}
