using AutoMapper;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;

namespace ProjetosAPI.Profiles
{
    public class VideoProfile:Profile
    {
        public VideoProfile()
        {
            CreateMap<VideoDto, Video>();
            CreateMap<Video, VideoRespostaDto>();
        }
    }
}
