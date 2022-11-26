using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class ProdutoProntoRespostaDto
    {
        public int Id { get; set; }
        public string Projeto { get; set; }
        public float Saldo { get; set; }
        public float Preco { get; set; }
    }
}
