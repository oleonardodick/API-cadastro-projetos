using AutoMapper;
using FluentResults;
using ProjetosAPI.Data;
using ProjetosAPI.Data.Dtos;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Services
{
    public class ProdutoProntoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProdutoProntoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProdutoProntoRespostaDto> BuscaProdutosPronto(int? projetoId)
        {
            float saldoEntrada = 0;
            float saldoSaida = 0;
            List<ProdutoPronto> produtosProntos;
            if (projetoId == null)
            {
                produtosProntos = _context.ProdutoPronto.ToList();
            }
            else
            {
                produtosProntos = _context.ProdutoPronto.Where(p => p.ProjetoId == projetoId).ToList();
            }
            if (produtosProntos != null)
            {
                List<ProdutoProntoRespostaDto> produtosProntosDto = _mapper.Map<List<ProdutoProntoRespostaDto>>(produtosProntos);
                for(int i = 0; i<produtosProntosDto.Count(); i++)
                {
                    saldoEntrada = _context.MovimentoProjeto.Where(mov => mov.ProdutoProntoId == produtosProntosDto[i].Id && mov.Tipo == 'E').Sum(mov => mov.Quantidade);
                    saldoSaida = _context.MovimentoProjeto.Where(mov => mov.ProdutoProntoId == produtosProntosDto[i].Id && mov.Tipo == 'S').Sum(mov => mov.Quantidade);
                    produtosProntosDto[i].Saldo = saldoEntrada - saldoSaida;
                    if(produtosProntosDto[i].Saldo == 0)
                    {
                        produtosProntosDto.Remove(produtosProntosDto[i]);
                    }
                }
                return produtosProntosDto;
            }
            return null;
        }

        public ProdutoProntoRespostaDto BuscaProdutoProntoPorId(int id)
        {
            ProdutoPronto produtoPronto = BuscaProdutoPronto(id);
            if (produtoPronto != null)
            {
                ProdutoProntoRespostaDto produtoProntoDto = _mapper.Map<ProdutoProntoRespostaDto>(produtoPronto);
                return produtoProntoDto;
            }
            return null;
        }

        public Result ExcluiProdutoPronto(int id)
        {
            ProdutoPronto produtoPronto = BuscaProdutoPronto(id);
            if (produtoPronto == null)
            {
                return Result.Fail("Produto Pronto não cadastrado");
            }
            else
            {
                _context.ProdutoPronto.Remove(produtoPronto);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private ProdutoPronto BuscaProdutoPronto(int id)
        {
            return _context.ProdutoPronto.FirstOrDefault(prodPronto => prodPronto.Id == id);
        }
    }
}
