using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Data.Dtos.Categoria;
using ProjetosAPI.Services;
using System.Collections.Generic;

namespace ProjetosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult CriaCategoria([FromBody]CategoriaDto categoriaDto)
        {
            CategoriaRespostaDto respostaDto = _categoriaService.CriaCategoria(categoriaDto);
            return CreatedAtAction(nameof(BuscaCategoriaPorId), new { id = respostaDto.Id }, respostaDto);
        }

        [HttpGet]
        public IActionResult BuscaCategorias()
        {
            List<CategoriaRespostaDto> categorias = _categoriaService.BuscaCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCategoriaPorId(int id)
        {
            CategoriaRespostaDto respostaDto = _categoriaService.BuscaCategoriaPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody]CategoriaDto categoriaAtualizada)
        {
            Result resultado = _categoriaService.AtualizaCategoria(id, categoriaAtualizada);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiCategoria(int id)
        {
            Result resultado = _categoriaService.ExcluiCategoria(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}