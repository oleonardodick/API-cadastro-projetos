using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjetosAPI.Models
{
    public class Movimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Material Material { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public float Quantidade { get; set; }
        public char Tipo { get; set; }
        public int OrdemProducaoId { get; set; }
    }
}
