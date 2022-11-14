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
    public class ProjetoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProjetoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProjetoRespostaDto CriaProjeto(ProjetoDto projetoDto)
        {
            Projeto projeto = _mapper.Map<Projeto>(projetoDto);
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
            return _mapper.Map<ProjetoRespostaDto>(projeto);
        }

        public List<ProjetoRespostaDto> BuscaProjetos(int? categoriaId)
        {
            List<Projeto> projetos;
            if(categoriaId == null)
            {
                projetos = _context.Projeto.ToList();
            } else
            {
                projetos = _context.Projeto.Where(projeto => projeto.CategoriaId == categoriaId).ToList();
            }
            if (projetos != null)
            {
                List<ProjetoRespostaDto> projetosDto = _mapper.Map<List<ProjetoRespostaDto>>(projetos);
                return projetosDto;
            }
            return null;
        }

        public ProjetoRespostaDto BuscaProjetoPorId(int id)
        {
            Projeto projeto = BuscaProjeto(id);
            if (projeto != null)
            {
                ProjetoRespostaDto projetoDto = _mapper.Map<ProjetoRespostaDto>(projeto);
                return projetoDto;
            }
            return null;
        }

        public Result AtualizaProjeto(int id, ProjetoDto projetoAtualizado)
        {
            Projeto projeto = BuscaProjeto(id);
            if (projeto == null)
            {
                return Result.Fail("Projeto não cadastrado");
            }
            else
            {
                _mapper.Map(projetoAtualizado, projeto);
                _context.Projeto.Update(projeto);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiProjeto(int id)
        {
            Projeto projeto = BuscaProjeto(id);
            if (projeto == null)
            {
                return Result.Fail("Projeto não cadastrado");
            }
            else
            {
                _context.Projeto.Remove(projeto);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Projeto BuscaProjeto(int id)
        {
            return _context.Projeto.FirstOrDefault(projeto => projeto.Id == id);
        }
    }
}
