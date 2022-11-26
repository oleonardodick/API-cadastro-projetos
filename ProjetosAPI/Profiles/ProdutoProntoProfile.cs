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
            CreateMap<ProdutoPronto, ProdutoProntoRespostaDto>()
                .ForMember(prod => prod.Projeto,
                opts => opts.MapFrom(prod => prod.Projeto.Descricao))
                .ForMember(prod => prod.Preco,
                opts => opts.MapFrom(prod => prod.Projeto.Preco));
        }
    }
}
