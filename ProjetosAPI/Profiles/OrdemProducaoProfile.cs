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
            CreateMap<OrdemProducaoUpdateDto, OrdemProducao>();
            CreateMap<OrdemProducao, OrdemProducaoRespostaDto>()
                .ForMember(opDto => opDto.Projeto,
                opts => opts.MapFrom(op => op.Projeto.Descricao));
        }
    }
}
