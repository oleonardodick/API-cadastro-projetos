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
    public class MovimentoController : ControllerBase
    {
        private MovimentoService _movimentoService;

        public MovimentoController(MovimentoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        [HttpPost]
        public IActionResult CriaMovimento([FromBody] MovimentoDto movimentoDto)
        {
            MovimentoRespostaDto respostaDto = _movimentoService.CriaMovimento(movimentoDto);
            return CreatedAtAction(nameof(BuscaMovimentoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaMovimentos()
        {
            List<MovimentoRespostaDto> respostaDto = _movimentoService.BuscaMovimentos();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaMovimentoPorId(int id)
        {
            MovimentoRespostaDto respostaDto = _movimentoService.BuscaMovimentoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaMovimento(int id, [FromBody] MovimentoDto movimentoAtualizado)
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