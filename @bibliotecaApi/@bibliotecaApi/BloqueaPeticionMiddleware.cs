namespace _bibliotecaApi
{
    public class BloqueaPeticionMiddleware
    {
        private readonly RequestDelegate next;

        public BloqueaPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext contexto)
        {
            if (contexto.Request.Path == "/Bloqueado")
            {
                contexto.Response.StatusCode = 403;
                await contexto.Response.WriteAsync("Aceso denegado");
            }
            else
            {
                await next.Invoke(contexto);
            }
        }
    }
    public static class BloqueaPeticionMiddlewareExtenxions
    {
        public static IApplicationBuilder UseBloqueadorPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BloqueaPeticionMiddleware>();
        }
    }
}
