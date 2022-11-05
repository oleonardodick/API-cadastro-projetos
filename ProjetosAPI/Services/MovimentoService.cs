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
    public class MovimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovimentoRespostaDto CriaMovimento(MovimentoDto movimentoDto)
        {
            Movimento movimento = _mapper.Map<Movimento>(movimentoDto);
            _context.Movimento.Add(movimento);
            _context.SaveChanges();
            return _mapper.Map<MovimentoRespostaDto>(movimento);
        }

        public List<MovimentoRespostaDto> BuscaMovimentos()
        {
            List<Movimento> movimentos;
            movimentos = _context.Movimento.ToList();
            if (movimentos != null)
            {
                List<MovimentoRespostaDto> respostaDto = _mapper.Map<List<MovimentoRespostaDto>>(movimentos);
                return respostaDto;
            }
            return null;
        }

        public MovimentoRespostaDto BuscaMovimentoPorId(int id)
        {
            Movimento movimento = BuscaMovimento(id);
            if (movimento != null)
            {
                MovimentoRespostaDto respostaDto = _mapper.Map<MovimentoRespostaDto>(movimento);
                return respostaDto;
            }
            return null;
        }

        public Result AtualizaMovimento(int id, MovimentoDto movimentoAtualizado)
        {
            Movimento movimento = BuscaMovimento(id);
            if (movimento == null)
            {
                return Result.Fail("Movimento não cadastrado");
            }
            else
            {
                _mapper.Map(movimentoAtualizado, movimento);
                _context.Movimento.Update(movimento);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiMovimento(int id)
        {
            Movimento movimento = BuscaMovimento(id);
            if (movimento == null)
            {
                return Result.Fail("Movimento não cadastrado");
            }
            else
            {
                _context.Movimento.Remove(movimento);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Movimento BuscaMovimento(int id)
        {
            return _context.Movimento.FirstOrDefault(video => video.Id == id);
        }
    }
}
