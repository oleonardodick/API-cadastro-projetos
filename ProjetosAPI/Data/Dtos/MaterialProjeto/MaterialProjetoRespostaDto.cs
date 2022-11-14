using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MaterialProjetoRespostaDto
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public int MaterialId { get; set; }
        public float Quantidade { get; set; }
        //[JsonIgnore]
        //public virtual Material Material { get; set; }
        public string nomeMaterial { get; set; }
    }
}
