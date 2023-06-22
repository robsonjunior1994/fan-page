﻿using System.ComponentModel.DataAnnotations;

namespace fan_page.Models
{
    public class Postagem : ClasseBase
    {
        public int IdUsario { get; set; }
        [Required]
        public string Conteudo { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public List<int> NumeroDeCurtidas { get; set; }
        public List<Comentario> Comentarios { get; set; }

    }
}
