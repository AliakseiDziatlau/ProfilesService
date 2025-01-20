namespace ProfilesService.Application.Configuration;

public static class ConfigurationSetup
{
    public static void AddCustomConfiguration(this ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<Program>(optional: true)
            .AddEnvironmentVariables();
    }
}