using Application;
using Host.Filters;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Host.ObjectResultExecutors;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers(options =>
{
    options.Filters.Add<AppExceptionFilterAttribute>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddInfrastructure(configuration);
services.AddApplication(configuration);

services.AddSingleton<ObjectResultExecutor>();
services.AddSingleton<IActionResultExecutor<ObjectResult>, EnvelopedObjectResultExecutor>();

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

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseInfrastructure();

app.UseHttpsRedirection();
app.MapControllers();

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.Run();
