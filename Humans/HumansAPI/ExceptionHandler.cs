using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace HumansAPI
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
              await  HandleExceptionAsync(context,ex);
               
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string titletext = "Internal Server Error";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;
            switch (exception)
            {
                case Exception _:
                    Serilog.Log.Error(exception, exception.Message);
                    exception = new Exception("Internal server error");
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(Result.Failure(
                    titletext : titletext,
                    statusCode :statusCode ,
                    traceId : traceId,
                    exception: exception)));
        }
    }
}
