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
    public class AnotacaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AnotacaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AnotacaoRespostaDto CriaAnotacao(AnotacaoDto anotacaoDto)
        {
            Anotacao anotacao = _mapper.Map<Anotacao>(anotacaoDto);
            _context.Anotacao.Add(anotacao);
            _context.SaveChanges();
            return _mapper.Map<AnotacaoRespostaDto>(anotacao);
        }

        public List<AnotacaoRespostaDto> BuscaAnotacoes()
        {
            List<Anotacao> anotacoes;
            anotacoes = _context.Anotacao.ToList();
            if(anotacoes != null)
            {
                List<AnotacaoRespostaDto> anotacoesDto = _mapper.Map<List<AnotacaoRespostaDto>>(anotacoes);
                return anotacoesDto;
            }
            return null;
        }

        public AnotacaoRespostaDto BuscaAnotacaoPorId(int id)
        {
            Anotacao anotacao = BuscaAnotacao(id);
            if(anotacao != null)
            {
                AnotacaoRespostaDto anotacaoDto = _mapper.Map<AnotacaoRespostaDto>(anotacao);
                return anotacaoDto;
            }
            return null;
        }

        public Result AtualizaAnotacao(int id, AnotacaoDto anotacaoAtualizada)
        {
            Anotacao anotacao = BuscaAnotacao(id);
            if(anotacao == null)
            {
                return Result.Fail("Anotação não cadastrada");
            }
            else
            {
                _mapper.Map(anotacaoAtualizada, anotacao);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiAnotacao(int id)
        {
            Anotacao anotacao = BuscaAnotacao(id);
            if(anotacao == null)
            {
                return Result.Fail("Anotação não cadastrada");
            }
            else
            {
                _context.Anotacao.Remove(anotacao);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Anotacao BuscaAnotacao(int id)
        {
            return _context.Anotacao.FirstOrDefault(anotacao => anotacao.Id == id);
        }
    }
}
