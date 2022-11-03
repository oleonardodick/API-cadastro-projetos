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
    public class MaterialController : ControllerBase
    {
        private MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        public IActionResult CriaMaterial([FromBody] MaterialDto materialDto)
        {
            MaterialRespostaDto respostaDto = _materialService.CriaMaterial(materialDto);
            return CreatedAtAction(nameof(BuscaMaterialPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaMateriais()
        {
            List<MaterialRespostaDto> respostaDto = _materialService.BuscaMateriais();
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaMaterialPorId(int id)
        {
            MaterialRespostaDto respostaDto = _materialService.BuscaMaterialPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaMaterial(int id, [FromBody] MaterialDto materialAtualizado)
        {
            Result resultado = _materialService.AtualizaMaterial(id, materialAtualizado);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiMaterial(int id)
        {
            Result resultado = _materialService.ExcluiMaterial(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}