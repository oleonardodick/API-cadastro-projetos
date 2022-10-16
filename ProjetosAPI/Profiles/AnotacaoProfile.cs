using AutoMapper;
using ProjetosAPI.Data.Dtos.Anotacao;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
