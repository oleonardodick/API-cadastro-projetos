using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos.Imagem
{
    public class ImagemRespostaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Descricao { get; set; }
    }
}
