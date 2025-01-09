using ProfilesService.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddCustomConfiguration(builder.Environment);
builder.ConfigureLogging();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.AddMiddlearesAndSwagger();

var app = builder.Build();
app.AddSwagger();
app.AddMiddlewares();
app.Run(); 