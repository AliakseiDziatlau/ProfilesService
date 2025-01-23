using ProfilesService.Application.Configuration;
using ProfilesService.Application.Configurations;
using ProfilesService.Presentation.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddCustomConfiguration(builder.Environment);
builder.ConfigureLogging();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.AddMiddlearesAndSwagger();
builder.Services.AddEventSubscriber(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   
            .AllowAnyMethod()    
            .AllowAnyHeader();  
    });
});

var app = builder.Build();
app.AddSwagger();
app.UseCors("AllowAll");
app.AddMiddlewares();
app.AddListeners(); 
app.Run(); 