using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MovimentoProjetoDto
    {
        [Required]
        public float Quantidade { get; set; }
        [Required]
        public char Tipo { get; set; }
        [Required]
        public Projeto Projeto { get; set; }
    }
}
