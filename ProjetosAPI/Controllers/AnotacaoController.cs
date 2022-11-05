using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Services;
using System.Collections.Generic;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnotacaoController : ControllerBase
    {
        private AnotacaoService _anotacaoService;

        public AnotacaoController(AnotacaoService anotacaoService)
        {
            _anotacaoService = anotacaoService;
        }

        [HttpPost]
        public IActionResult CriaAnotacao([FromBody] AnotacaoDto anotacaoDto)
        {
            AnotacaoRespostaDto respostaDto = _anotacaoService.CriaAnotacao(anotacaoDto);
            return CreatedAtAction(nameof(BuscaAnotacaoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaAnotacoes()
        {
            List<AnotacaoRespostaDto> respostaDto = _anotacaoService.BuscaAnotacoes();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaAnotacaoPorId(int id)
        {
            AnotacaoRespostaDto respostaDto = _anotacaoService.BuscaAnotacaoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAnotacao (int id, [FromBody] AnotacaoDto anotacaoAtualizada)
        {
            Result resultado = _anotacaoService.AtualizaAnotacao(id, anotacaoAtualizada);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiAnotacao(int id)
        {
            Result resultado = _anotacaoService.ExcluiAnotacao(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}