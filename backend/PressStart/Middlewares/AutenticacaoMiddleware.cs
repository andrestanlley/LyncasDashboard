using PressStart.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace PressStart.Middlewares
{
    public class AutenticacaoMiddleware
    {
        private readonly RequestDelegate _next;

        public AutenticacaoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAutenticacaoService autenticacaoService)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                string email = credentials[0];
                string senha = credentials[1];

                context.Items["Usuario"] = await autenticacaoService.VerificarCredenciais(email, senha);
            }
            catch
            {}

            await _next(context);
        }
    }
}

