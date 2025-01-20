using FluentValidation.AspNetCore;

namespace ProfilesService.Application.Configuration;

public static class MiddlewareOnBuilderSetup
{
    public static void AddMiddlearesAndSwagger(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication();
        services.AddControllers().AddFluentValidation(config =>
        {
            config.RegisterValidatorsFromAssemblyContaining<Program>();
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpClient();
    }
}