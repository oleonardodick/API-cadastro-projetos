using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetosAPI.Models
{
    public class Material
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string UnidadeMedida { get; set; }
        [JsonIgnore]
        public virtual List<Movimento> Movimentos { get; set; }
    }
}
