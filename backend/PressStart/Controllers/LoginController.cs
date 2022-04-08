using Microsoft.AspNetCore.Mvc;
using PressStart.Dtos.Request;
using PressStart.Dtos.Response;
using PressStart.Interfaces;

namespace PressStart.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;
        public LoginController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UsuarioResponse>> Login([FromBody] LoginPostRequest model)
        {
            return Ok(await _autenticacaoService.VerificarCredenciais(model.Email, model.Senha));
        }
    }
}