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
    public class ProdutoProntoController : ControllerBase
    {
        private ProdutoProntoService _produtoProntoService;

        public ProdutoProntoController(ProdutoProntoService produtoProntoService)
        {
            _produtoProntoService = produtoProntoService;
        }

        [HttpGet]
        public IActionResult BuscaProdutosProntos([FromQuery] int? projetoId = null)
        {
            List<ProdutoProntoRespostaDto> respostaDto = _produtoProntoService.BuscaProdutosPronto(projetoId);
            return Ok(respostaDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaProdutoProntoPorId(int id)
        {
            ProdutoProntoRespostaDto respostaDto = _produtoProntoService.BuscaProdutoProntoPorId(id);
            if (respostaDto != null) return Ok(respostaDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiProdutoPronto(int id)
        {
            Result resultado = _produtoProntoService.ExcluiProdutoPronto(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}