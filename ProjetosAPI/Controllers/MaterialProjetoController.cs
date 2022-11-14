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
    public class MaterialProjetoController : ControllerBase
    {
        private MaterialProjetoService _materialProjetoService;

        public MaterialProjetoController(MaterialProjetoService materialProjetoService)
        {
            _materialProjetoService = materialProjetoService;
        }

        [HttpPost]
        public IActionResult CriaMaterialProjeto([FromBody] MaterialProjetoDto matProjetoDto)
        {
            MaterialProjetoRespostaDto respostaDto = _materialProjetoService.CriaMaterialProjeto(matProjetoDto);
            return CreatedAtAction(nameof(BuscaMaterialProjetoPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaMateriaisProjeto([FromQuery] int? projetoId = null)
        {
            List<MaterialProjetoRespostaDto> respostaDto = _materialProjetoService.BuscaMateriaisProjeto(projetoId);
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaMaterialProjetoPorId(int id)
        {
            MaterialProjetoRespostaDto respostaDto = _materialProjetoService.BuscaMaterialProjetoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaMaterialProjeto(int id, [FromBody] MaterialProjetoDto materialProjetoAtualizado)
        {
            Result resultado = _materialProjetoService.AtualizaMaterialProjeto(id, materialProjetoAtualizado);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiMaterialProjeto(int id)
        {
            Result resultado = _materialProjetoService.ExcluiMaterialProjeto(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}