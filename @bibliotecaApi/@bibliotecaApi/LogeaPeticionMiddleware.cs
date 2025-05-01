namespace _bibliotecaApi
{
    public class LogeaPeticionMiddleware
       
    {
        private readonly RequestDelegate next;

        public LogeaPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext contexto)
        {
            //viene la peticion
            var logger = contexto.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"peticion:{contexto.Request.Method}{contexto.Request.Path}");

            await next.Invoke(contexto);

            //se va la repuesta

            logger.LogInformation($"Respuesta{contexto.Response.StatusCode}");
        }
    }

    public static class LogeaPeticionMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogueaPeticion (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogeaPeticionMiddleware>();
        }
    }
}

