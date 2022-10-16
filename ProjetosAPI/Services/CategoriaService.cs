using AutoMapper;
using FluentResults;
using ProjetosAPI.Data;
using ProjetosAPI.Data.Dtos.Categoria;
using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Services
{
    public class CategoriaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoriaRespostaDto CriaCategoria(CategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return _mapper.Map<CategoriaRespostaDto>(categoria);
        }

        public List<CategoriaRespostaDto> BuscaCategorias()
        {
            List<Categoria> categorias;
            categorias = _context.Categoria.ToList();
            if(categorias != null)
            {
                List<CategoriaRespostaDto> categoriaDto = _mapper.Map<List<CategoriaRespostaDto>>(categorias);
                return categoriaDto;
            }
            return null;
        }

        public CategoriaRespostaDto BuscaCategoriaPorId(int id)
        {
            Categoria categoria = BuscaCategoria(id);
            if(categoria != null)
            {
                CategoriaRespostaDto categoriaDto = _mapper.Map<CategoriaRespostaDto>(categoria);
                return categoriaDto;
            }
            return null;
        }

        public Result AtualizaCategoria(int id, CategoriaDto categoriaAtualizada)
        {
            Categoria categoria = BuscaCategoria(id);
            if(categoria == null)
            {
                return Result.Fail("Categoria não cadastrada");
            }
            else
            {
                _mapper.Map(categoriaAtualizada, categoria);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiCategoria(int id)
        {
            Categoria categoria = BuscaCategoria(id);
            if(categoria == null)
            {
                return Result.Fail("Categoria não cadastrada");
            } 
            else
            {
                _context.Remove(categoria);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Categoria BuscaCategoria(int id)
        {
            return _context.Categoria.FirstOrDefault(categoria => categoria.Id == id);
        }
    }
}
