using AutoMapper;
using PressStart.Constants;
using PressStart.Dtos.Response;
using PressStart.Functions;
using PressStart.Interfaces;
using PressStart.Models;

namespace PressStart.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public AutenticacaoService(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        public async Task<UsuarioResponse> VerificarCredenciais(string email, string senha){
            Pessoa usuario = await _usuarioService.ChecarLogin(email);
            senha = CriptografarSenha.SHA1(senha);
            if(senha != usuario.Autenticacao.Senha)
                throw new BadHttpRequestException(Aviso.UNAUTHORIZED, 401);
            return _mapper.Map<UsuarioResponse>(usuario);
        }
    }
}