using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MaterialProjetoDto
    {
        [Required]
        public int ProjetoId { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public float Quantidade { get; set; }
    }
}
