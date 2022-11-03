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
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set; }
        public string Capa { get; set; }
        public Categoria Categoria { get; set; }
        public object Imagens { get; set; }
        public object Anotacoes { get; set; }
        public object Videos { get; set; }
        public object MovimentosProjeto { get; set; }
    }
}
