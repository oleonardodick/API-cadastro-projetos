using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class ProjetoRespostaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Capa { get; set; }
        public int CategoriaId { get; set; }
    }
}
