using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Services;
using System.Collections.Generic;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimentoProjetoController : ControllerBase
    {
        private MovimentoProjetoService _movimentoService;

        public MovimentoProjetoController(MovimentoProjetoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        [HttpPost]
        public IActionResult CriaMovimento([FromBody] MovimentoProjetoDto movimentoDto)
        {
            MovimentoProjetoRespostaDto respostaDto = _movimentoService.CriaMovimento(movimentoDto);
            return CreatedAtAction(nameof(BuscaMovimentoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaMovimentos()
        {
            List<MovimentoProjetoRespostaDto> respostaDto = _movimentoService.BuscaMovimentos();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaMovimentoPorId(int id)
        {
            MovimentoProjetoRespostaDto respostaDto = _movimentoService.BuscaMovimentoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaMovimento(int id, [FromBody] MovimentoProjetoDto movimentoAtualizado)
        {
            Result resultado = _movimentoService.AtualizaMovimento(id, movimentoAtualizado);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiMovimento(int id)
        {
            Result resultado = _movimentoService.ExcluiMovimento(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}