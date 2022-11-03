using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class MovimentoProjetoRespostaDto
    {
        public int Id { get; set; }
        public float Quantidade { get; set; }
        public char Tipo { get; set; }
        public int ProjetoId { get; set; }
    }
}
