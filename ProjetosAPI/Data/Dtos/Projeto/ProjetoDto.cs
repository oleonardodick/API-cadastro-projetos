using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class ProjetoDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set; }
        public string Capa { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
