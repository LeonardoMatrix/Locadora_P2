using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Locacao
    {
        [Key]
        public int CodigoLocacao { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Decimal Valor { get; set; }
        public Cliente Cliente { get; set; }

    }
}