using System.Text.Json;
using TWJobs.Api.Common;
using TWJobs.Core.Exceptions;

namespace TWJobs.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ModelNotFoundException e)
        {
            await handleModelNotFoundExceptionAsync(context, e);
        }
    }

    private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e)
    {
        var body = new ErrorResponse
        {
            Status = 404,
            Error = "Not Found",
            Cause = e.GetType().Name,
            Message = e.Message,
            Timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}