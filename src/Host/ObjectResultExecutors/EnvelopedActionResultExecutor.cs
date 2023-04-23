using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Host.ObjectResultExecutors;

internal class EnvelopedObjectResultExecutor : IActionResultExecutor<ObjectResult>
{
    private readonly ObjectResultExecutor _innerExecutor;

    public EnvelopedObjectResultExecutor(
        ObjectResultExecutor innerExecutor)
    {
        _innerExecutor = innerExecutor;
    }

    public async Task ExecuteAsync(ActionContext context, ObjectResult result)
    {
        // Determine the success status based on the HTTP status code
        int statusCode = context.HttpContext.Response.StatusCode;
        bool success = result.StatusCode switch
        {
            int code when code >= 200 && code < 300 => true,
            null => statusCode >= 200 && statusCode < 300,
            _ => false
        };

        // Wrap the result in an envelope model
        var response = new ResponseEnvelope<object>
        {
            Success = success,
            Message = result.Value
        };

        // Create a new ObjectResult with the envelope model
        var envelopedResult = new ObjectResult(response)
        {
            StatusCode = result.StatusCode,
            DeclaredType = typeof(ResponseEnvelope<object>),
            ContentTypes = result.ContentTypes,
            Formatters = result.Formatters
        };

        // Execute the enveloped result using the inner executor
        await _innerExecutor.ExecuteAsync(context, envelopedResult);
    }
}

internal class ResponseEnvelope<T>
{
    public bool Success { get; set; }
    public T? Message { set; get; }
}
