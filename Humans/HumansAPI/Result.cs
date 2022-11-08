namespace HumansAPI
{
    public class Result
    {
        public static object Failure(string titletext, int statusCode, string traceId, Exception exception) => new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            title = titletext,
            statusCode = statusCode,
            traceId = traceId,
            errors = new
            {
                messages = new string[] { exception.InnerException?.InnerException?.Message ?? exception.InnerException?.Message ?? exception.Message }
            }
        };
            
    }
}
