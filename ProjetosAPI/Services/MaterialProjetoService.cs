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
    public class MaterialProjetoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MaterialProjetoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MaterialProjetoRespostaDto CriaMaterialProjeto(MaterialProjetoDto matProjetoDto)
        {
            MaterialProjeto matProjeto = _mapper.Map<MaterialProjeto>(matProjetoDto);
            _context.MaterialProjeto.Add(matProjeto);
            _context.SaveChanges();
            return _mapper.Map<MaterialProjetoRespostaDto>(matProjeto);
        }

        public List<MaterialProjetoRespostaDto> BuscaMateriaisProjeto(int? projetoId)
        {
            List<MaterialProjeto> matProjetos;
            if (projetoId == null)
            {
                matProjetos = _context.MaterialProjeto.ToList();
            }
            else
            {
                matProjetos = _context.MaterialProjeto.Where(m => m.ProjetoId == projetoId).ToList();
            }
            if (matProjetos != null)
            {
                List<MaterialProjetoRespostaDto> matProjetosDto = _mapper.Map<List<MaterialProjetoRespostaDto>>(matProjetos);
                return matProjetosDto;
            }
            return null;
        }

        public MaterialProjetoRespostaDto BuscaMaterialProjetoPorId(int id)
        {
            MaterialProjeto matProjeto = BuscaMaterialProjeto(id);
            if (matProjeto != null)
            {
                MaterialProjetoRespostaDto matProjetoDto = _mapper.Map<MaterialProjetoRespostaDto>(matProjeto);
                return matProjetoDto;
            }
            return null;
        }

        public Result AtualizaMaterialProjeto(int id, MaterialProjetoDto materialProjetoAtualizado)
        {
            MaterialProjeto matProjeto = BuscaMaterialProjeto(id);
            if (matProjeto == null)
            {
                return Result.Fail("Anotação não cadastrada");
            }
            else
            {
                _mapper.Map(materialProjetoAtualizado, matProjeto);
                _context.MaterialProjeto.Update(matProjeto);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiMaterialProjeto(int id)
        {
            MaterialProjeto matProjeto = BuscaMaterialProjeto(id);
            if (matProjeto == null)
            {
                return Result.Fail("Anotação não cadastrada");
            }
            else
            {
                _context.MaterialProjeto.Remove(matProjeto);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private MaterialProjeto BuscaMaterialProjeto(int id)
        {
            return _context.MaterialProjeto.FirstOrDefault(matProjeto => matProjeto.Id == id);
        }
    }
}
