using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class ProdutoPronto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProjetoId { get; set; }
        [JsonIgnore]
        public virtual Projeto Projeto { get; set; }
        [JsonIgnore]
        public virtual List<MovimentoProjeto> Movimentos { get; set; }
    }
}
