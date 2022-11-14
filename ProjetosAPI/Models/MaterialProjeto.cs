using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class MaterialProjeto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        [Required]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        [Required]
        public float Quantidade { get; set; }
    }
}
