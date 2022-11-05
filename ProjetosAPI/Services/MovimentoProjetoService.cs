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
    public class MovimentoProjetoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovimentoProjetoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovimentoProjetoRespostaDto CriaMovimento(MovimentoProjetoDto movimentoDto)
        {
            MovimentoProjeto movimento = _mapper.Map<MovimentoProjeto>(movimentoDto);
            _context.MovimentoProjeto.Add(movimento);
            _context.SaveChanges();
            return _mapper.Map<MovimentoProjetoRespostaDto>(movimento);
        }

        public List<MovimentoProjetoRespostaDto> BuscaMovimentos()
        {
            List<MovimentoProjeto> movimentos;
            movimentos = _context.MovimentoProjeto.ToList();
            if(movimentos != null)
            {
                List<MovimentoProjetoRespostaDto> movimentosDto = _mapper.Map<List<MovimentoProjetoRespostaDto>>(movimentos);
                return movimentosDto;
            }
            return null;
        }

        public MovimentoProjetoRespostaDto BuscaMovimentoPorId(int id)
        {
            MovimentoProjeto movimento = BuscaMovimento(id);
            if(movimento != null)
            {
                MovimentoProjetoRespostaDto movimentoDto = _mapper.Map<MovimentoProjetoRespostaDto>(movimento);
                return movimentoDto;
            }
            return null;
        }

        public Result AtualizaMovimento(int id, MovimentoProjetoDto movimentoAtualizado)
        {
            MovimentoProjeto movimento = BuscaMovimento(id);
            if(movimento == null)
            {
                return Result.Fail("Movimento não encontrado");
            }
            else
            {
                _mapper.Map(movimentoAtualizado, movimento);
                _context.MovimentoProjeto.Update(movimento);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiMovimento(int id)
        {
            MovimentoProjeto movimento = BuscaMovimento(id);
            if(movimento == null)
            {
                return Result.Fail("Movimento não encontrado");
            }
            else
            {
                _context.MovimentoProjeto.Remove(movimento);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private MovimentoProjeto BuscaMovimento(int id)
        {
            return _context.MovimentoProjeto.FirstOrDefault(movimento => movimento.Id == id);
        }
    }
}
