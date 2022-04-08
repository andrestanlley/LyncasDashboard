using AutoMapper;
using PressStart.Dtos.Request;
using PressStart.Dtos.Response;
using PressStart.Models;

namespace PressStart.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioPostRequest, Pessoa>()
                .ForPath(x => x.Autenticacao.Senha, s => s.MapFrom(x => x.Senha))
                .ForPath(x => x.Autenticacao.Estado, e => e.MapFrom(x => x.Estado))
                .ReverseMap();

            CreateMap<Pessoa, UsuarioResponse>()
                .ForMember(x => x.Estado, e => e.MapFrom(x => x.Autenticacao.Estado))
                .ReverseMap();
                
            CreateMap<UsuarioPutRequest, Pessoa>()
                .ForPath(x => x.Autenticacao.Senha, s => s.MapFrom(x => x.Senha))
                .ForPath(x => x.Autenticacao.Estado, e => e.MapFrom(x => x.Estado))
                .ReverseMap();
        }
    }
}