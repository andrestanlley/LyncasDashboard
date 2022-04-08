using Microsoft.AspNetCore.Mvc;
using PressStart.Authorization;
using PressStart.Constants;
using PressStart.Dtos.Request;
using PressStart.Dtos.Response;
using PressStart.Interfaces;


namespace PressStart.Controllers
{
    [Authorize]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        //Criar um método para listar todos os usuários (obterTodos) utilizando o verbo http GET
        //Deve trazer os dados pertinentes para a listagem, utilizando as duas tabelas(Pessoa e Autenticacao)
        [HttpGet]
        [Route("obterTodos")]
        public async Task<ActionResult<IEnumerable<UsuarioResponse>>> ObterTodos()
        {
            return Ok(await _usuarioService.ObterTodos());
        }

        //Criar um método para obter um usuário por ID (obterPorId) utilizando o verbo http GET
        [HttpGet]
        [Route("obterPorId/{id:int}")]
        public async Task<ActionResult<UsuarioResponse>> ObterPorId(int id)
        {
            return Ok(await _usuarioService.ObterPorId(id));
        }

        //Criar um método para salvar usuário utilizando o verbo http POST
        //Salvar o usuário utilizando as duas tabelas(Pessoa e Autenticação)
        [HttpPost]
        [Route("salvarUsuario")]
        public async Task<ActionResult<UsuarioResponse>> Salvar(
        [FromBody] UsuarioPostRequest model)
        {
            UsuarioResponse usuario = await _usuarioService.Salvar(model);
            return Ok(new {message = Aviso.USER_CREATED, usuario});
        }

        //Criar um método para editar usuário utilizando o verbo http PUT
        [HttpPut]
        [Route("editarUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioResponse>> Atualizar(int id, [FromBody] UsuarioPutRequest model)
        {
            UsuarioResponse UsuarioAtualizado = await _usuarioService.Atualizar(id, model);
            return Ok(new { message = Aviso.USER_UPDATED, UsuarioAtualizado });
        }

        //Criar um método para editar usuário utilizando o verbo http DELETE
        //O usuário deve ser removido das duas tabelas(Pessoa e Autenticacao)
        [HttpDelete]
        [Route("excluirUsuario/{id:int}")]
        public async Task<ActionResult> Deletar(int id)
        {
            await _usuarioService.Deletar(id);
            return Ok(new { message = Aviso.USER_DELETED, idDeletado = id });
        }
    }
}
