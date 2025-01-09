using MediatR;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.Repositories;

namespace ProfilesService.Application.Configuration;

public static class DependencyInjectionSetup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        services.AddMediatR(typeof(Program));
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
    }
}