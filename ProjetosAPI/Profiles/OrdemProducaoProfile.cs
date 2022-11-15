using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class OrdemProducaoProfile:Profile
    {
        public OrdemProducaoProfile()
        {
            CreateMap<OrdemProducaoDto, OrdemProducao>();
            CreateMap<OrdemProducao, OrdemProducaoRespostaDto>();
        }
    }
}
