using Microsoft.AspNetCore.Http;

namespace Infrastructure.Auth;

internal class CurrentUserMiddleware : IMiddleware
{
    private readonly ICurrentUserInitializer _initializer;

    public CurrentUserMiddleware(ICurrentUserInitializer initializer)
    {
        _initializer = initializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _initializer.SetCurrentUser(context.User);

        await next(context);
    }
}
