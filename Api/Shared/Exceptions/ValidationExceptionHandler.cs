using FluentValidation;

namespace Api.Shared.Exceptions;

public class ValidationExceptionHandler
{
    private readonly RequestDelegate _next;

    public ValidationExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                errors = ex.Errors.Select(x => new
                {
                    field = x.PropertyName,
                    message = x.ErrorMessage
                })
            });
        }
    }
}