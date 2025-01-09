namespace ProfilesService.Application.Configuration;

public static class MiddlewareOnBuilderSetup
{
    public static void AddMiddlearesAndSwagger(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpClient();
    }
}