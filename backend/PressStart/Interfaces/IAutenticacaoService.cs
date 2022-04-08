using PressStart.Dtos.Response;

namespace PressStart.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<UsuarioResponse> VerificarCredenciais(string email, string senha);
    }
}