using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class AnotacaoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public int ProjetoId { get; set; }
    }
}
