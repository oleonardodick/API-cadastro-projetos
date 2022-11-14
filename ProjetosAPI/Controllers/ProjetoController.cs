using System.Collections.Generic;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Services;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private ProjetoService _projetoService;

        public ProjetoController(ProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost]
        public IActionResult CriaProjeto([FromBody]ProjetoDto projetoDto)
        {
            ProjetoRespostaDto respostaDto = _projetoService.CriaProjeto(projetoDto);
            return CreatedAtAction(nameof(BuscaProjetoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaProjetos([FromQuery] int? categoriaId = null)
        {
            List<ProjetoRespostaDto> projetos = _projetoService.BuscaProjetos(categoriaId);
            if (projetos != null) return Ok(projetos);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscaProjetoPorId(int id)
        {
            ProjetoRespostaDto respostaDto = _projetoService.BuscaProjetoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaProjeto(int id, [FromBody]ProjetoDto projetoAtualizado)
        {
            Result resultado = _projetoService.AtualizaProjeto(id, projetoAtualizado);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiProjeto(int id)
        {
            Result resultado = _projetoService.ExcluiProjeto(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}