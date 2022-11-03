using AutoMapper;
using FluentResults;
using ProjetosAPI.Data;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetosAPI.Services
{
    public class VideoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public VideoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VideoRespostaDto CriaVideo(VideoDto videoDto)
        {
            Video video = _mapper.Map<Video>(videoDto);
            _context.Video.Add(video);
            _context.SaveChanges();
            return _mapper.Map<VideoRespostaDto>(video);
        }

        public List<VideoRespostaDto> BuscaVideos()
        {
            List<Video> videos;
            videos = _context.Video.ToList();
            if(videos != null)
            {
                List<VideoRespostaDto> respostaDto = _mapper.Map<List<VideoRespostaDto>>(videos);
                return respostaDto;
            }
            return null;
        }

        public VideoRespostaDto BuscaVideoPorId(int id)
        {
            Video video = BuscaVideo(id);
            if(video != null)
            {
                VideoRespostaDto respostaDto = _mapper.Map<VideoRespostaDto>(video);
                return respostaDto;
            }
            return null;
        }

        public Result AtualizaVideo(int id, VideoDto videoAtualizado)
        {
            Video video = BuscaVideo(id);
            if(video == null)
            {
                return Result.Fail("Vídeo não cadastrdo");
            }
            else
            {
                _mapper.Map(videoAtualizado, video);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiVideo(int id)
        {
            Video video = BuscaVideo(id);
            if (video == null)
            {
                return Result.Fail("Vídeo não cadastrado");
            }
            else
            {
                _context.Remove(video);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Video BuscaVideo(int id)
        {
            return _context.Video.FirstOrDefault(video => video.Id == id);
        }
    }
}
