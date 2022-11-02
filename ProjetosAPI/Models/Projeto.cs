using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Projeto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set; }
        public string Capa { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<Imagem> Imagens { get; set; }
        public virtual List<Anotacao> Anotacoes { get; set; }
        public virtual List<Video> Videos { get; set; }
    }
}
