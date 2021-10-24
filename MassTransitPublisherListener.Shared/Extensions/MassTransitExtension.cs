using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MassTransitPublisherListener.Shared.Extensions
{
    public static class MassTransitExtension
    {
        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration, Action<IServiceCollectionBusConfigurator> configBus = null)
        {
            var massTransitSection = configuration.GetSection("MassTransit");
            var url = massTransitSection.GetValue<string>("Uri");
            var userName = massTransitSection.GetValue<string>("Username");
            var password = massTransitSection.GetValue<string>("Password");

            if (massTransitSection == null || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Section 'mass-transit' configuration settings are not found in appsettings.json");
            }

            services.AddMassTransit(x =>
            {
                configBus?.Invoke(x);

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host
                    (
                        new Uri(url),
                        hostdata =>
                        {
                            hostdata.Username(userName);
                            hostdata.Password(password);
                        }
                    );

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService(true);
        }
    }
}
