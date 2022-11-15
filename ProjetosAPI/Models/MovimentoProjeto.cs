using System.ComponentModel.DataAnnotations;

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
        public int ProdutoProntoId { get; set; }
        public virtual ProdutoPronto ProdutoPronto { get; set; }
    }
}
