using PressStart.Dtos.Request;
using PressStart.Dtos.Response;
using PressStart.Models;

namespace PressStart.Interfaces
{
    public interface IUsuarioService
    {
        Task<Pessoa> ChecarLogin(string email);
        Task<IEnumerable<UsuarioResponse>> ObterTodos();
        Task<UsuarioResponse> ObterPorId(int id);
        Task<UsuarioResponse> Salvar(UsuarioPostRequest model);
        Task<UsuarioResponse> Atualizar(int id, UsuarioPutRequest model);
        Task Deletar(int id);
    }
}