using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class AnotacaoProfile:Profile
    {
        public AnotacaoProfile()
        {
            CreateMap<AnotacaoDto, Anotacao>();
            CreateMap<Anotacao, AnotacaoRespostaDto>();
        }
    }
}
