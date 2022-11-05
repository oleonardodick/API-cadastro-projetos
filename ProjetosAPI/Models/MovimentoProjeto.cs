using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class MovimentoProjeto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public float Quantidade { get; set; }
        [Required]
        public char Tipo { get; set; }
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        [Required]
        public char Status { get; set; }
    }
}
