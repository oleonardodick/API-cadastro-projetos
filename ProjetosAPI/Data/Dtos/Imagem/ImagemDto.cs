﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetosAPI.Data.Dtos
{
    public class ImagemDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Caminho { get; set; }
        public string Descricao { get; set; }
        public int ProjetoId { get; set; }
    }
}
