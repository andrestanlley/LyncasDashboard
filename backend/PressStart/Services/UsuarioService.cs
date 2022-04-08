using System.Text.RegularExpressions;
using AutoMapper;
using PressStart.Constants;
using PressStart.Dtos.Request;
using PressStart.Dtos.Response;
using PressStart.Functions;
using PressStart.Interfaces;
using PressStart.Models;

namespace PressStart.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<Pessoa> ChecarLogin(string email)
        {
            Pessoa? usuario = await _usuarioRepository.ChecarLogin(email);
            if(usuario is null)
                throw new BadHttpRequestException(Aviso.UNAUTHORIZED, 401);
            return usuario;
        }

        public async Task<IEnumerable<UsuarioResponse>> ObterTodos()
        {
            IEnumerable<Pessoa> usuarios = await _usuarioRepository.ObterTodos();
            if (usuarios is null || !usuarios.Any())
                throw new BadHttpRequestException(Aviso.NO_USERS, 404);
            return _mapper.Map<List<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse> ObterPorId(int id)
        {
            UsuarioResponse usuario = _mapper.Map<UsuarioResponse>(await _usuarioRepository.ObterPorId(id));
            if (usuario is null)
                throw new BadHttpRequestException(Aviso.NO_ID_RESULT, 404);
            return usuario;
        }

        public async Task<UsuarioResponse> Salvar(UsuarioPostRequest model)
        {
            model.Telefone = Regex.Replace(model.Telefone, @"\D", "");
            model.Senha = CriptografarSenha.SHA1(model.Senha);
            Pessoa usuario = _mapper.Map<Pessoa>(model);
            Pessoa novoUsuario = await _usuarioRepository.Salvar(usuario);
            
            return _mapper.Map<UsuarioResponse>(novoUsuario);
        }

        public async Task<UsuarioResponse> Atualizar(int id, UsuarioPutRequest model)
        {
            Pessoa? usuarioId = await _usuarioRepository.ObterPorId(id);
            if (usuarioId is null)
                throw new BadHttpRequestException(Aviso.NO_ID_RESULT, 404);
            if (model.Senha is null || model.Senha == "")
            {
                model.Senha = usuarioId.Autenticacao.Senha;
            }else{
                model.Senha = CriptografarSenha.SHA1(model.Senha);
            }
            Pessoa usuario = _mapper.Map(model, usuarioId);
            Pessoa usuarioAtualizado = await _usuarioRepository.Atualizar(usuario);
            return _mapper.Map<UsuarioResponse>(usuarioAtualizado);
        }

        public async Task Deletar(int id)
        {
            Pessoa? model = await _usuarioRepository.ObterPorId(id);
            if (model is null)
                throw new BadHttpRequestException(Aviso.NO_ID_RESULT, 404);
            await _usuarioRepository.Deletar(model);
        }
    }
}