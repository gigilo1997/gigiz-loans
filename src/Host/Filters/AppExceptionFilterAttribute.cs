using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Host.Filters;

public class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
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
        else if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
        }
        else
        {
            HandleUnknownException(context);
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
