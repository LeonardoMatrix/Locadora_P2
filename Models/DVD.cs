using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class DVD
    {
        [Key]
        public int ID { get; set; }
        public Video Video { get; set; } 
        public Locacao Locacao { get; set; }

    }
}