using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Video
    {
        [Key]
        public int CodigoVideo { get; set; }
        public Sessao Sessao { get; set; }
        public String Titulo { get; set; }
        public String Disponibilidade { get; set; }
        public int QuantidadeEstoque { get; set; }
        public String Genero { get; set; }

    }
}