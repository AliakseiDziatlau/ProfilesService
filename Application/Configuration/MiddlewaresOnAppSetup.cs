using ProfilesService.Presentation.Middlewares;
using Serilog;

namespace ProfilesService.Application.Configuration;

public static class MiddlewaresOnAppSetup
{
    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseMiddleware<AuthorizationMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}