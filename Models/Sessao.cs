using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Sessao
    {
        [Key]
        public int ID { get; set; }
        public String Descricao { get; set; }
        public String Localizacao { get; set; }

    }
}