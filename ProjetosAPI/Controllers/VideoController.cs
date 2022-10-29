using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos.Video;
using ProjetosAPI.Services;
using System.Collections.Generic;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public IActionResult CriaVideo([FromBody] VideoDto videoDto)
        {
            VideoRespostaDto respostaDto = _videoService.CriaVideo(videoDto);
            return CreatedAtAction(nameof(BuscaVideoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaVideos()
        {
            List<VideoRespostaDto> respostaDto = _videoService.BuscaVideos();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaVideoPorId(int id)
        {
            VideoRespostaDto respostaDto = _videoService.BuscaVideoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, [FromBody] VideoDto videoAtualizado)
        {
            Result resultado = _videoService.AtualizaVideo(id, videoAtualizado);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiVideo(int id)
        {
            Result resultado = _videoService.ExcluiVideo(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}