using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class ProdutoProntoProfile:Profile
    {
        public ProdutoProntoProfile()
        {
            CreateMap<ProdutoProntoDto, ProdutoPronto>();
            CreateMap<ProdutoPronto, ProdutoProntoRespostaDto>();
        }
    }
}
