using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class OrdemProducaoRespostaDto
    {
        public int Id { get; set; }
        public string Projeto { get; set; }
        public float Quantidade { get; set; }
        public char Status { get; set; }
    }
}
