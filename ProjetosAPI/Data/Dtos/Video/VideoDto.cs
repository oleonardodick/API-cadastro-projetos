using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class VideoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Link { get; set; }
        public string Descricao { get; set; }
        public int ProjetoId { get; set; }
    }
}
