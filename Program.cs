using System.Data;
using MediatR;
using Microsoft.Data.SqlClient;
using ProfilesService.Application.Interfaces;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.EnvironmentName;
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
   

//DB configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));

//DI container configuration
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); 
    });
}   

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run(); 