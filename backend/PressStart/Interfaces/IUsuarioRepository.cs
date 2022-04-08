using PressStart.Dtos.Request;
using PressStart.Models;

namespace PressStart.Interfaces{
    public interface IUsuarioRepository
    {
        Task<Pessoa?> ChecarLogin(string email);
        Task<IEnumerable<Pessoa>> ObterTodos();
        Task<Pessoa?> ObterPorId(int id);
        Task<Pessoa> Salvar(Pessoa usuario);
        Task<Pessoa> Atualizar(Pessoa model);
        Task Deletar(Pessoa model);
    }
}