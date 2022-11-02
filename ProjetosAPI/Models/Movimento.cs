using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Movimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Material Material { get; set; }
        public int MaterialId { get; set; }
        [Required]
        public float Quantidade { get; set; }
    }
}
