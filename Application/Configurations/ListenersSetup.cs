using ProfilesService.Presentation.Services;

namespace ProfilesService.Application.Configurations;

public static class ListenersSetup
{
    public static void AddListeners(this WebApplication app)
    {
        var eventSubscriber = app.Services.GetRequiredService<EventSubscriber>();
        Task.Run(() => eventSubscriber.StartListening());
        app.Lifetime.ApplicationStopping.Register(() =>
        {
            eventSubscriber.Close(); 
        });
    }
}