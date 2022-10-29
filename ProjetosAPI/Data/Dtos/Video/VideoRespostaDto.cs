using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos.Video
{
    public class VideoRespostaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
