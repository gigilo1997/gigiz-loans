using Application.Common.Behaviors;
using Application.User.Commands;
using Application.User.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Make validators work
        //services.AddFluentValidation();
        //services.AddFluentValidationAutoValidation()
        //    .AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        //services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();

        //services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}
