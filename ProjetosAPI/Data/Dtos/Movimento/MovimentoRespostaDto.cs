using ProjetosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MovimentoRespostaDto
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public float Quantidade { get; set; }
        public char Tipo { get; set; }
    }
}
