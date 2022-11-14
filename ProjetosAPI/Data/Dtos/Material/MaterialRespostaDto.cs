using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MaterialRespostaDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public float Saldo { get; set; }
        [JsonIgnore]
        public virtual List<Movimento> Movimentos{ get; set; }
    }
}
