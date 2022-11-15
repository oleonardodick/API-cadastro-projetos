using ProjetosAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetosAPI.Data.Dtos
{ 
    public class MovimentoDto
    {
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public float Quantidade { get; set; }
        [Required]
        public char Tipo { get; set; }
        public int OrdemProducaoId { get; set; }
    }
}
