using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual List<Imagem> Imagens { get; set; }
        [JsonIgnore]
        public virtual List<Anotacao> Anotacoes { get; set; }
        [JsonIgnore]
        public virtual List<Video> Videos { get; set; }
        [JsonIgnore]
        public virtual List<MovimentoProjeto> MovimentosProjeto { get; set; }
    }
}
