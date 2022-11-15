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
    public class OrdemProducaoController : ControllerBase
    {
        private OrdemProducaoService _ordemProducaoService;

        public OrdemProducaoController(OrdemProducaoService ordemProducaoService)
        {
            _ordemProducaoService = ordemProducaoService;
        }

        [HttpPost]
        public IActionResult CriaOrdemProducao([FromBody] OrdemProducaoDto ordemProducaoDto)
        {
            OrdemProducaoRespostaDto respostaDto = _ordemProducaoService.CriaOrdemProducao(ordemProducaoDto);
            return CreatedAtAction(nameof(BuscaOrdemProducaoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaOrdensProducao([FromQuery] char? status = null)
        {
            List<OrdemProducaoRespostaDto> respostaDto = _ordemProducaoService.BuscaOrdensProducao(status);
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaOrdemProducaoPorId(int id)
        {
            OrdemProducaoRespostaDto respostaDto = _ordemProducaoService.BuscaOrdemProducaoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaOrdemProducao(int id, [FromBody] OrdemProducaoUpdateDto ordemProducaoAtualizada)
        {
            Result resultado = _ordemProducaoService.AtualizaOrdemProducao(id, ordemProducaoAtualizada);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiOrdemProducao(int id)
        {
            Result resultado = _ordemProducaoService.ExcluiOrdemProducao(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}