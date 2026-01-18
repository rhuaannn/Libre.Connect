using System.Net;
using System.Text.Json;
using Libre.Connect.Domain.Exception;
using Libre.Connect.Model;

namespace Libre.Connect.Middleware;

public class GlobalMiddlewareExceptions
{
    private readonly RequestDelegate _next;

    public GlobalMiddlewareExceptions(RequestDelegate next)
    {
         _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = HttpStatusCode.InternalServerError;
        var message = "Ocorreu um erro inesperado no servidor.";
        var errors = new List<string>();

        switch (exception)
        {
            case ExceptionNotFound: 
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
                break;
            
            case DomainException:  
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;
            
            case ExceptionBadRequest:  
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse<object>.ErrorResponse(new List<string> { message });

        var jsonResponse = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(jsonResponse);
    }
}