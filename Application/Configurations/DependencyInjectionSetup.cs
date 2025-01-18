using MediatR;
using ProfilesService.Application.Handlers.ReceptionistHandlers;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.Repositories;

namespace ProfilesService.Application.Configuration;

public static class DependencyInjectionSetup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        services.AddMediatR(typeof(Program));
        services.AddMediatR(typeof(UpdateReceptionistPhoneNumberHandler).Assembly);
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
    }
}