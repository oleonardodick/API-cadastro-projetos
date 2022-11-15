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
    public class OrdemProducaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private MovimentoService _movimentoService;
        private ProdutoProntoService _produtoProntoService;

        public OrdemProducaoService(AppDbContext context, IMapper mapper, MovimentoService movimentoService, ProdutoProntoService produtoPronto)
        {
            _context = context;
            _mapper = mapper;
            _movimentoService = movimentoService;
            _produtoProntoService = produtoPronto;
        }

        public OrdemProducaoRespostaDto CriaOrdemProducao(OrdemProducaoDto ordemProducaoDto)
        {
            OrdemProducao ordemProducao = _mapper.Map<OrdemProducao>(ordemProducaoDto);
            MovimentoDto movimentoDto = new MovimentoDto();
            List<MaterialProjeto> materialProjeto = _context.MaterialProjeto.Where(mp => mp.ProjetoId == ordemProducao.ProjetoId).ToList();
            _context.OrdemProducao.Add(ordemProducao);
            _context.SaveChanges();
            foreach (MaterialProjeto matProj in materialProjeto)
            {
                movimentoDto.MaterialId = matProj.MaterialId;
                movimentoDto.Quantidade = matProj.Quantidade * ordemProducao.Quantidade;
                movimentoDto.Tipo = 'S';
                movimentoDto.OrdemProducaoId = ordemProducao.Id;
                _movimentoService.CriaMovimento(movimentoDto);
            }
            
            return _mapper.Map<OrdemProducaoRespostaDto>(ordemProducao);
        }

        public List<OrdemProducaoRespostaDto> BuscaOrdensProducao(char? status)
        {
            List<OrdemProducao> ordensProducao;
            if (status == null)
            {
                ordensProducao = _context.OrdemProducao.ToList();
            }
            else
            {
                ordensProducao = _context.OrdemProducao.Where(op => op.Status == status).ToList();
            }
            if (ordensProducao != null)
            {
                List<OrdemProducaoRespostaDto> ordensProducaoDto = _mapper.Map<List<OrdemProducaoRespostaDto>>(ordensProducao);
                return ordensProducaoDto;
            }
            return null;
        }

        public OrdemProducaoRespostaDto BuscaOrdemProducaoPorId(int id)
        {
            OrdemProducao ordemProducao = BuscaOrdemProducao(id);
            if (ordemProducao != null)
            {
                OrdemProducaoRespostaDto ordemProducaoDto = _mapper.Map<OrdemProducaoRespostaDto>(ordemProducao);
                return ordemProducaoDto;
            }
            return null;
        }

        public Result AtualizaOrdemProducao(int id, OrdemProducaoUpdateDto ordemProducaoAtualizada)
        {
            OrdemProducao ordemProducao = BuscaOrdemProducao(id);
            if (ordemProducao == null)
            {
                return Result.Fail("Ordem Produção não cadastrada");
            }
            else
            {
                if(ordemProducao.Status == 'F')
                {
                    return Result.Fail("Ordem de produção já finalizada. Impossível modificar");
                } else
                {
                    if (ordemProducao.Status != ordemProducaoAtualizada.Status)
                    {
                        _mapper.Map(ordemProducaoAtualizada, ordemProducao);
                        _context.OrdemProducao.Update(ordemProducao);

                        if (ordemProducaoAtualizada.Status == 'F')
                        {
                            ProdutoPronto produtoPronto = new ProdutoPronto();
                            produtoPronto.ProjetoId = ordemProducao.ProjetoId;
                            _context.ProdutoPronto.Add(produtoPronto);

                            MovimentoProjeto movProjeto = new MovimentoProjeto();
                            movProjeto.ProdutoPronto = produtoPronto;
                            movProjeto.ProdutoProntoId = produtoPronto.Id;
                            movProjeto.Quantidade = ordemProducao.Quantidade;
                            movProjeto.Tipo = 'E';
                            _context.MovimentoProjeto.Add(movProjeto);
                        }
                        else
                        {
                            Movimento movimento = _context.Movimento.FirstOrDefault(mov => mov.OrdemProducaoId == ordemProducao.Id);
                            _context.Movimento.Remove(movimento);
                        }
                        _context.SaveChanges();
                    }
                    return Result.Ok();
                } 
            }
        }

        public Result ExcluiOrdemProducao(int id)
        {
            OrdemProducao ordemProducao = BuscaOrdemProducao(id);
            if (ordemProducao == null)
            {
                return Result.Fail("Ordem Produção não cadastrada");
            }
            else
            {
                Movimento movimento = _context.Movimento.FirstOrDefault(mov => mov.OrdemProducaoId == ordemProducao.Id);
                _context.OrdemProducao.Remove(ordemProducao);
                _context.Movimento.Remove(movimento);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private OrdemProducao BuscaOrdemProducao(int id)
        {
            return _context.OrdemProducao.FirstOrDefault(op => op.Id == id);
        }
    }
}
