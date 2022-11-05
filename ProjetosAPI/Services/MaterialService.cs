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
    public class MaterialService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public MaterialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MaterialRespostaDto CriaMaterial(MaterialDto materialDto)
        {
            Material material = _mapper.Map<Material>(materialDto);
            _context.Material.Add(material);
            _context.SaveChanges();
            return _mapper.Map<MaterialRespostaDto>(material);
        }

        public List<MaterialRespostaDto> BuscaMateriais()
        {
            List<Material> materiais;
            materiais = _context.Material.ToList();
            if (materiais != null)
            {
                List<MaterialRespostaDto> materiaisDto = _mapper.Map<List<MaterialRespostaDto>>(materiais);
                return materiaisDto;
            }
            return null;
        }

        public MaterialRespostaDto BuscaMaterialPorId(int id)
        {
            Material material = BuscaMaterial(id);
            if (material != null)
            {
                MaterialRespostaDto materialDto = _mapper.Map<MaterialRespostaDto>(material);
                return materialDto;
            }
            return null;
        }

        public Result AtualizaMaterial(int id, MaterialDto materialAtualizado)
        {
            Material material = BuscaMaterial(id);
            if (material == null)
            {
                return Result.Fail("Material não cadastrado");
            }
            else
            {
                _mapper.Map(materialAtualizado, material);
                _context.Material.Update(material);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiMaterial(int id)
        {
            Material material = BuscaMaterial(id);
            if (material == null)
            {
                return Result.Fail("Material não cadastrado");
            }
            else
            {
                _context.Material.Remove(material);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Material BuscaMaterial(int id)
        {
            return _context.Material.FirstOrDefault(material => material.Id == id);
        }
    }
}
