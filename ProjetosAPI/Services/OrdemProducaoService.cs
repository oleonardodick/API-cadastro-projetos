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

        public OrdemProducaoService(AppDbContext context, IMapper mapper, MovimentoService movimentoService)
        {
            _context = context;
            _mapper = mapper;
            _movimentoService = movimentoService;
        }

        public OrdemProducaoRespostaDto CriaOrdemProducao(OrdemProducaoDto ordemProducaoDto)
        {
            OrdemProducao ordemProducao = _mapper.Map<OrdemProducao>(ordemProducaoDto);
            MovimentoDto movimentoDto = new MovimentoDto();
            List<MaterialProjeto> materialProjeto = _context.MaterialProjeto.Where(mp => mp.ProjetoId == ordemProducao.ProjetoId).ToList();
            foreach (MaterialProjeto matProj in materialProjeto)
            {
                movimentoDto.MaterialId = matProj.MaterialId;
                movimentoDto.Quantidade = matProj.Quantidade * ordemProducao.Quantidade;
                movimentoDto.Tipo = 'S';
                _movimentoService.CriaMovimento(movimentoDto);
            }
            _context.OrdemProducao.Add(ordemProducao);
            _context.SaveChanges();
            return _mapper.Map<OrdemProducaoRespostaDto>(ordemProducao);
        }

        public List<OrdemProducaoRespostaDto> BuscaOrdensProducao(int? projetoId)
        {
            List<OrdemProducao> ordensProducao;
            if (projetoId == null)
            {
                ordensProducao = _context.OrdemProducao.ToList();
            }
            else
            {
                ordensProducao = _context.OrdemProducao.Where(op => op.ProjetoId == projetoId).ToList();
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

        public Result AtualizaOrdemProducao(int id, OrdemProducaoDto ordemProducaoAtualizada)
        {
            OrdemProducao ordemProducao = BuscaOrdemProducao(id);
            if (ordemProducao == null)
            {
                return Result.Fail("Ordem Produção não cadastrada");
            }
            else
            {
                _mapper.Map(ordemProducaoAtualizada, ordemProducao);
                _context.OrdemProducao.Update(ordemProducao);
                _context.SaveChanges();
                return Result.Ok();
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
                _context.OrdemProducao.Remove(ordemProducao);
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
