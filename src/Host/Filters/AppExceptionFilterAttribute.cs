﻿using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Host.Filters;

public class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<AppExceptionFilterAttribute> _logger;

    public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();

        if (type == typeof(AppValidationException))
        {
            HandleValidationException(context);
        }
        else if (type == typeof(AppBadRequestException))
        {
            HandleBadRequestException(context);
        }
        else if (type == typeof(AppForbiddenException))
        {
            HandleForbiddenException(context);
        }
        else if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
        }
        else
        {
            HandleUnknownException(context);
            _logger.LogError("Exception occured: {@Exception}", context.Exception);
        }

        context.ExceptionHandled = true;

        base.OnException(context);
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = context.Exception as AppValidationException;

        var details = new ValidationProblemDetails(exception!.Errors);

        context.Result = new BadRequestObjectResult(details);
    }

    private void HandleBadRequestException(ExceptionContext context)
    {
        var exception = context.Exception as AppBadRequestException;

        var details = new ValidationProblemDetails(exception!.Errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "There was an issue with your request",
        };

        context.Result = new BadRequestObjectResult(details);
    }

    private void HandleForbiddenException(ExceptionContext context)
    {
        var exception = context.Exception as AppForbiddenException;

        var details = new ProblemDetails
        {
            Status = StatusCodes.Status403Forbidden,
            Title = exception!.Message,
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status403Forbidden
        };
    }

    private void HandleInvalidModelStateException(ExceptionContext context)
    {
        var details = new ValidationProblemDetails(context.ModelState);

        context.Result = new BadRequestObjectResult(details);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request."
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
