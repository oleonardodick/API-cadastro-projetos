using AutoMapper;
using ProjetosAPI.Data.Dtos.Categoria;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Profiles
{
    public class CategoriaProfile:Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<Categoria, CategoriaRespostaDto>();
        }
    }
}
