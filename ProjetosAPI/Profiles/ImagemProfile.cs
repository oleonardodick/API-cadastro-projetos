using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class ImagemProfile:Profile
    {
        public ImagemProfile()
        {
            CreateMap<ImagemDto, Imagem>();
            CreateMap<Imagem, ImagemRespostaDto>();
        }
    }
}
