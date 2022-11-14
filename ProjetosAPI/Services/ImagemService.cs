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
    public class ImagemService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ImagemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ImagemRespostaDto CriaImagem(ImagemDto imagemDto)
        {
            Imagem imagem = _mapper.Map<Imagem>(imagemDto);
            _context.Imagem.Add(imagem);
            _context.SaveChanges();
            return _mapper.Map<ImagemRespostaDto>(imagem);
        }

        public List<ImagemRespostaDto> BuscaImagens(int? projetoId)
        {
            List<Imagem> imagens;
            if(projetoId == null)
            {
                imagens = _context.Imagem.ToList();
            } else
            {
                imagens = _context.Imagem.Where(i => i.ProjetoId == projetoId).ToList();
            }
            if(imagens != null)
            {
                List<ImagemRespostaDto> respostaDto = _mapper.Map<List<ImagemRespostaDto>>(imagens);
                return respostaDto;
            }
            return null;
        }

        public ImagemRespostaDto BuscaImagemPorId(int id)
        {
            Imagem imagem = BuscaImagem(id);
            if(imagem != null)
            {
                ImagemRespostaDto respostaDto = _mapper.Map<ImagemRespostaDto>(imagem);
                return respostaDto;
            }
            return null;
        }

        public Result AtualizaImagem(int id, ImagemDto imagemAtualizada)
        {
            Imagem imagem = BuscaImagem(id);
            if(imagem == null)
            {
                return Result.Fail("Imagem não cadastrada");
            }
            else
            {
                _mapper.Map(imagemAtualizada, imagem);
                _context.Imagem.Update(imagem);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        public Result ExcluiImagem(int id)
        {
            Imagem imagem = BuscaImagem(id);
            if(imagem == null)
            {
                return Result.Fail("Imagem não cadastrada");
            }
            else
            {
                _context.Imagem.Remove(imagem);
                _context.SaveChanges();
                return Result.Ok();
            }
        }

        private Imagem BuscaImagem(int id)
        {
            return _context.Imagem.FirstOrDefault(imagem => imagem.Id == id);
        }
    }
}
