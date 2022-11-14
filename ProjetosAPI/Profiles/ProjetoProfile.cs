using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class ProjetoProfile:Profile
    {
        public ProjetoProfile()
        {
            CreateMap<ProjetoDto, Projeto>();
            CreateMap<Projeto, ProjetoRespostaDto>();
        }
    }
}
