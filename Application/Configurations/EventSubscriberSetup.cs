using MediatR;
using ProfilesService.Presentation.Services;

namespace ProfilesService.Application.Configurations;

public static class EventSubscriberSetup
{
    public static void AddEventSubscriber(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(sp =>
        {
            var hostname = configuration.GetValue<string>("RabbitMQ:HostName") ?? "localhost";
            return new EventSubscriber(hostname, sp);
        });
    }
}