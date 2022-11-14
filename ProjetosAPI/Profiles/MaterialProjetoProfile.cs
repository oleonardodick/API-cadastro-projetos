using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Profiles
{
    public class MaterialProjetoProfile:Profile
    {
        public MaterialProjetoProfile()
        {
            CreateMap<MaterialProjetoDto, MaterialProjeto>();
            CreateMap<MaterialProjeto, MaterialProjetoRespostaDto>()
                .ForMember(matProjeto => matProjeto.nomeMaterial,
                opts => opts.MapFrom(m => m.Material.Nome));
        }
    }
}
