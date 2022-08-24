
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace WeatherDetailsApi.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
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
                var response = context.Response;
                response.ContentType = "application/json";
                string responseModel;
                //TODO - add more such cases of custom error caught by the application to show proper message to UI hiding the stack trace
                switch (error)
                {
                    //TODO - log exception message, stack trace and other details here
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel = e.Message;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel = e.Message;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel = "Internal server Error";
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
