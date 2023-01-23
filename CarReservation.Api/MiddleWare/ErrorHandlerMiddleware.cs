using CarReservation.Application.Exception;
using CarReservation.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace CarReservation.Api.MiddleWare;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string> { Succeded = false, Message = error?.Message };
            switch (error)
            {
                case ApiException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = new List<string> { e.Message };
                    break;

                case ValidationException e:
                    // custom applicaton error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;

                case KeyNotFoundException:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            string? result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}

