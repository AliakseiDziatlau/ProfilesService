using System.Data;
using Microsoft.Data.SqlClient;

namespace ProfilesService.Application.Configuration;

public static class DatabaseSetup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));
    }
}