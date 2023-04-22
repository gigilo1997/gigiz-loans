using Application;
using Host.Filters;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers(options =>
{
    options.Filters.Add<AppExceptionFilterAttribute>();
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddInfrastructure(configuration);
services.AddApplication(configuration);

builder.Logging.ClearProviders();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

await app.Services.InitializeDatabaseAsync(true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseInfrastructure();

app.UseHttpsRedirection();
app.MapControllers();

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.Run();
