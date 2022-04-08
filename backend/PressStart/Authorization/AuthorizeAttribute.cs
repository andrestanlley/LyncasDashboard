using Microsoft.AspNetCore.Mvc.Filters;
using PressStart.Constants;
using PressStart.Dtos.Response;

namespace PressStart.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            UsuarioResponse usuario = (UsuarioResponse)context.HttpContext.Items["Usuario"];
            if (usuario is null)
            {
                context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
                throw new BadHttpRequestException(Aviso.UNAUTHORIZED, 401);
            }
        }
    }
}
