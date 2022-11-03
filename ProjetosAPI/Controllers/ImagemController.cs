using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Services;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagemController : ControllerBase
    {
        private ImagemService _imagemService;

        public ImagemController(ImagemService imagemService)
        {
            _imagemService = imagemService;
        }

        [HttpPost]
        public IActionResult CriaImagem([FromBody] ImagemDto imagemDto)
        {
            ImagemRespostaDto respostaDto = _imagemService.CriaImagem(imagemDto);
            return CreatedAtAction(nameof(BuscaImagemPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaImagens()
        {
            List<ImagemRespostaDto> respostaDto = _imagemService.BuscaImagens();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaImagemPorId(int id)
        {
            ImagemRespostaDto respostaDto = _imagemService.BuscaImagemPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaImagem(int id, [FromBody] ImagemDto imagemAtualizada)
        {
            Result resultado = _imagemService.AtualizaImagem(id, imagemAtualizada);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiImagem(int id)
        {
            Result resultado = _imagemService.ExcluiImagem(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}