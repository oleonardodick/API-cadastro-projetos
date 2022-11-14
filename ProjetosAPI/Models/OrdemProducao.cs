using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class OrdemProducao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        [Required]
        public float Quantidade { get; set; }
        public char Status { get; set; }
    }
}
