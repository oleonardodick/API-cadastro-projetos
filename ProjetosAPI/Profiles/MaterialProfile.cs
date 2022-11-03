using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Profiles
{
    public class MaterialProfile:Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialDto, Material>();
            CreateMap<Material, MaterialRespostaDto>();
        }
    }
}
